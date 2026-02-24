#!/usr/bin/env python3
import sys
import signal
import socket
import threading
import time
import LGCDdriver
from LGCDdriver import LG_IN, LG_OUT, safe_sleep, stop_event
from adafruit_servokit import ServoKit

# I2C Adressen
I2CSERVO = 0x40
I2CLG = 0x41

current_thread = None
current_event = None

delay = 6
lg_lock = threading.Lock()

PORT_CONST = 4443
MODE = 0

# Kanal-Index Konstanten (wie vorher)
LC = 1
RC = 2
LO = 3
RO = 4
LF = 5
RF = 6
AB = 7
LG = 8

# Default-Werte
angleLC = 128
angleRC = 128
angleLO = 128
angleRO = 128
angleAB = 128
angleLF = 128
angleRF = 128
fractionLG = LG_IN

# Socket initialisieren
try:
    HOST = ''
    PORT = PORT_CONST
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server_socket.bind((HOST, PORT))
    server_socket.listen(5)
    print(f"Server waits for {HOST}:{PORT}")
except Exception as e:
    print(f"Server could not be started: {e}")
    sys.exit(1)

# ServoKit initialisieren
try:
    servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=333)
except Exception as e:
    print(f"(SERVO) ServoKit could not be initialized: {e}")
    servodriver = None

# LGdriver initialisieren und Manager starten
try:
    LGdriver = ServoKit(channels=16, address=0x41,frequency=30)
    # Startet den Manager-Thread, der den Last-Value-Buffer überwacht
    LGCDdriver.start_manager(CDchannel=[0,1,2], CDdriver=servodriver)
except Exception as e:
    print(f"(LG) Fehler beim Initialisieren des LG-Managers: {e}")

def setpulsewidth():
    for channel in range(16):
        try:
            servodriver.servo[channel].set_pulse_width_range(1000,2000)
        except Exception:
            pass

def signaltoangle(signal_byte):
    return int(signal_byte * 0.703125)

def PWMsetServo_EF():
    try:
        servodriver.servo[3].angle = signaltoangle(angleLC)
        servodriver.servo[4].angle = signaltoangle(angleRC)
        servodriver.servo[5].angle = signaltoangle(angleLO)
        servodriver.servo[6].angle = signaltoangle(angleRO)
        servodriver.servo[7].angle = signaltoangle(angleAB)
        servodriver.servo[8].angle = signaltoangle(angleLF)
        servodriver.servo[9].angle = signaltoangle(angleRF)
        servodriver.servo[10].angle = 90
        servodriver.servo[11].angle = 90
        servodriver.servo[12].angle = 90
        servodriver.servo[13].angle = 90
        servodriver.servo[14].angle = 90
        servodriver.servo[15].angle = 90
    except Exception as e:
        print(f"(EF) Fehler beim Ansteuern der Servos: {e}")


def RuheModus():
    try:
        for numservo in range(3,16):
            servodriver.servo[numservo].angle = 90
        # LG einfahren über request_lg (letzter Wert wird verwendet)
        LGCDdriver.request_lg(LG_IN)
        safe_sleep(delay)
        for numservo in range(3):
            servodriver.servo[numservo].angle = 90
        for numservo in range(16):
            try:
                servodriver.servo[numservo].angle = None
            except Exception:
                pass
        LGCDdriver.request_lg(None)
        safe_sleep(delay)
    except Exception as e:
        print(f"Fehler beim Ansteuern der Servos: {e}")

def ServoTest():
    # Achtung: blockierend; nur im Testmodus verwenden
    while receivedData[MODE] == 3:
        for cylce in range(2):
            for angle in range(0, 180):
                for servoNum in range(0, 16):
                    servodriver.servo[servoNum].angle = angle
                    safe_sleep(0.5)
            LGCDdriver.request_lg(LG_OUT)
        RuheModus()

def handle_exit(signum, frame):
    print("Exiting. Please wait", end="\r")
    RuheModus()
    stop_event.set()
    try:
        if 'client_socket' in globals() and client_socket is not None:
            client_socket.close()
    except Exception:
        pass
    try:
        if 'server_socket' in globals() and server_socket is not None:
            server_socket.close()
    except Exception:
        pass
    try:
        LGCDdriver.shutdown()
    except Exception:
        pass
    print("Disconnected successfully".ljust(50))
    sys.exit(0)

signal.signal(signal.SIGINT, handle_exit)

# Main server loop
while not stop_event.is_set():
    try:
        print("Wait for Connection...")
        client_socket, addr = server_socket.accept()
        print(f"Connected to {addr} succesfull")
    except Exception as e:
        print(f"Connection cannot be established: {e}")
        break

    setpulsewidth()
    try:
        while True:
            receivedData = client_socket.recv(16)
            if not receivedData:
                break

            printData = ','.join(str(byte) for byte in receivedData)
            print(f"Received data: {printData}")

            # Update local variables
            angleLC = receivedData[LC]
            angleRC = receivedData[RC]
            angleLO = receivedData[LO]
            angleRO = receivedData[RO]
            angleAB = receivedData[AB]
            angleLF = receivedData[LF]
            angleRF = receivedData[RF]
            fractionLG = receivedData[LG]

            print(threading.active_count(), "threads")

            if receivedData[MODE] == 0:
                print("RuheModus")
                RuheModus()

            elif receivedData[MODE] == 1:
                print("Remote-Mode")
                # map fraction to LG state and request it (last-value buffer)
                state = fractionLG
                LGCDdriver.request_lg(state)
                PWMsetServo_EF()

            elif receivedData[MODE] == 3:
                print("Servotest")
                ServoTest()

            else:
                print("Received corrupted data")
                RuheModus()

    except Exception as e:
        print(f"Connection error: {e}")
    finally:
        try:
            client_socket.close()
        except Exception:
            pass

# Clean shutdown if loop exits
handle_exit(None, None)
