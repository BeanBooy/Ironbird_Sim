import sys
import signal
import socket
import threading
import ServoTest_Driver
import time
import LGCD_Driver
from ServoClass import Servo
from LGCD_Driver import LG_IN,stop_event
from adafruit_servokit import ServoKit

# I2C Adresses
I2CSERVO = 0x40

# TCP-Port
PORT_CONST = 4443
MODE = 0 # Idle as default / first BUS-Element

# index for each TCP-Bus-Part
iLC = 1  # Left Canards
iRC = 2  # Right Canards
iLO = 3  # Left Aileron (Outboard, Querruder)
iRO = 4  # Right Aileron
iLF = 5	# Flaps Inboard
iRF = 6 # Flaps Outboard
iAB = 7 # Airbrakes
iRU = 8 # Rudder
iLG = 9 # Landing Gear

# Defaultangles
RCD = Servo(channel=0,idle=0)
LCD = Servo(channel=1,idle=0)
RU = Servo(channel=2,idle=90)
LC = Servo(channel=3,idle=128)
RC = Servo(channel=4,idle=128)
LO = Servo(channel=5,idle=128)
RO = Servo(channel=6,idle=128)
LF = Servo(channel=7,idle=128)
RF = Servo(channel=8,idle=128)
AB = Servo(channel=9,idle=0)
#LG = Servo(channel=15,idle=0, min_pulsewidth=500, max_pulsewidth=2250)

try:
    # initialize socket
    HOST = '' # We are the Server
    PORT = PORT_CONST
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server_socket.bind((HOST, PORT))
    server_socket.listen(5)
    print(f"Server waits for {HOST}:{PORT}")
except Exception as e:
    print(f"Server could not be started: {e}")
    sys.exit(1)

try:
    servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=30)
except Exception as e:
    print(f"(SERVO) ServoKit could not be initialized: {e}")
    servodriver = None

# init LGdriver and start thread-manager
try:
    LGCD_Driver.start_manager()
except Exception as e:
    print(f"(LG) Error starting LG-Managers: {e}")

def PWMsetServo_EF():
    try:
        # channel 0 - 2 reserved for cabindoors
        LC.move(angleLC)
        RC.move(angleRC)
        LO.move(angleLO)
        RO.move(angleRO)
        LF.move(angleLF)
        RF.move(angleRF)
        AB.move(angleAB)
        RU.move(angleRU)
    except Exception as e:
        print(f"(EF) Error controlling servos: {e}")


def IdleMode():
    try:
        LC.move(LC.idle)
        RC.move(RC.idle)
        LO.move(LO.idle)
        RO.move(RO.idle)
        LF.move(LF.idle)
        RF.move(RF.idle)
        AB.move(AB.idle)
        RU.move(RU.idle)
        LGCD_Driver.request_lg(LG_IN)
        # detach all servos if possible
        LC.move(None)
        RC.move(None)
        LO.move(None)
        RO.move(None)
        LF.move(None)
        RF.move(None)
        AB.move(None)
        RU.move(None)
        LCD.move(None)
        RCD.move(None)
        #LG.move(None)
    except Exception as e:
        print(f"FError controlling servos: {e}")

def handle_exit(signum, frame): # signum, frame needed for call via signal.signal
    print("Stopping... Please wait", end="\r")
    IdleMode()
    stop_event.set() # set the thread-flag to stop starting new threads
    ServoTest_Driver.stop_servo_test()
    # close TCP-PORT
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
        # stop remaining threads
        LGCD_Driver.shutdown()
    except Exception:
        pass
    print("Disconnected successfully".ljust(50))
    sys.exit(0)

# handle exit for Keyboardinterrupt-event
signal.signal(signal.SIGINT, handle_exit)
#-------------------------------------------------------------------------------------------
# Main server loop
while not stop_event.is_set():
    try:
        IdleMode() # in case client closes connection
        print("Wait for Connection...")
        client_socket, addr = server_socket.accept()
        print(f"Connected to {addr} succesfull")
    except Exception as e:
        print(f"Connection cannot be established: {e}")
        break
    try:
        while True:
            receivedData = client_socket.recv(16)
            if not receivedData:
                break

            printData = ','.join(str(byte) for byte in receivedData)
            print(f"Received data: {printData}")

            angleLC = receivedData[iLC]
            angleRC = receivedData[iRC]
            angleLO = receivedData[iLO]
            angleRO = receivedData[iRO]
            angleAB = receivedData[iAB]
            angleLF = receivedData[iLF]
            angleRF = receivedData[iRF]
            angleRU = receivedData[iRU]
            fractionLG = receivedData[iLG] # 0 is min, 1 max pulsewidth (LG dooesnt need in between)

            print(threading.active_count(), "threads")

            if receivedData[MODE] == 0:
                ServoTest_Driver.stop_servo_test()
                print("IdleMode")
                IdleMode()
                time.sleep(0.02)
            elif receivedData[MODE] == 1:
                ServoTest_Driver.stop_servo_test()
                print("Remote-Mode")
                # map fraction to LG state and request it (last-value buffer)
                LGCD_Driver.request_lg(fractionLG)
                PWMsetServo_EF()

            elif receivedData[MODE] == 2:
                print("Servotest")
                ServoTest_Driver.start_servo_test()
                IdleMode()
            else:
                print("Received corrupted data")
                IdleMode()

    except Exception as e:
        print(f"Connection error: {e}")
    finally:
        try:
            client_socket.close()
        except Exception:
            pass
handle_exit(None,None)