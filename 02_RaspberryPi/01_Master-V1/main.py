import sys
import signal
import socket
import threading
import Servotestdriver
import LGCDdriver
from LGCDdriver import LG_IN, LG_OUT, safe_sleep, stop_event
from Servotestdriver import ServoTest, signal_inverter, stop_test
from adafruit_servokit import ServoKit

# I2C Adresses
I2CSERVO = 0x40


current_thread = None
current_event = None

delay = 6 # Delay in seconds for LG-Sequence
lock = threading.Lock()
# TCP-Port
PORT_CONST = 4443
MODE = 0 # Idle as default

# signal 1 - 3 reserved for Cabindoor
LC = 1  # Left Canards
RC = 2  # Right Canards
LO = 3  # Left Aileron (Outboard, Querruder)
RO = 4  # Right Aileron
LF = 5	# Flaps Inboard
RF = 6 # Flaps Outboard
AB = 7 # Airbrakes
LG = 8 # Landing Gear

# Defaultangles
angleLC = 128
angleRC = 128
angleLO = 128
angleRO = 128
angleAB = 128
angleLF = 128
angleRF = 128
fractionLG = LG_IN

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

# init ServoKitobjects
try:
    # NOTE Frequency only 333Hz for digital servos! Read your servo-datasheet to avoid damage
    servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=30)
except Exception as e:
    print(f"(SERVO) ServoKit could not be initialized: {e}")
    servodriver = None

# init LGdriver, Servotestdriver and start thread-manager
try:
    LGCDdriver.start_manager(CDchannel=[0,1,2], CDdriver=servodriver)
except Exception as e:
    print(f"(LG) Error starting LG-Managers: {e}")

def setpulsewidth():
    # for digital servos here but the values are default for many other servos, ignore channel 15 (LG)
    for channel in range(15):
        try:
            servodriver.servo[channel].set_pulse_width_range(1000,2000)
        except Exception:
            pass
# We receive 8 bytes (0 - 256) for each servo, except LG
def signaltoangle(signal_byte):
    return int(signal_byte * 0.703125)

# For inverted servos to behave normal. NOTE needs to be added manualy for each servochannel where an inverted servo is connected
# see signal_inverter in Servotestdriver

def PWMsetServo_EF():
    try:
        # channel 0 - 2 reserved for cabindoors
        servodriver.servo[3].angle = signaltoangle(angleLC)
        servodriver.servo[4].angle = signaltoangle(angleRC)
        servodriver.servo[5].angle = signaltoangle(angleLO)
        servodriver.servo[6].angle = signal_inverter(signaltoangle(angleRO))
        servodriver.servo[7].angle = signaltoangle(angleAB)
        servodriver.servo[8].angle = signaltoangle(angleLF)
        servodriver.servo[9].angle = signaltoangle(angleRF)
        servodriver.servo[10].angle = 90
        servodriver.servo[11].angle = 90
        servodriver.servo[12].angle = 90
        servodriver.servo[13].angle = 90
        servodriver.servo[14].angle = 90
        #servodriver.servo[15].fraction = receivedData[15]
    except Exception as e:
        print(f"(EF) Error controlling servos: {e}")


def IdleMode():
    try:
        for numservo in range(3,15):
            if servodriver.servo[numservo].angle is not None:
                if numservo == 7:
                    servodriver.servo[7].angle = 0
                else:
                    servodriver.servo[numservo].angle = 90
        # set LG to idle (LG_IN)
        #if servodriver.servo[15].angle is not None:
        LGCDdriver.request_lg(LG_IN)
        for numservo in range(16):
            try:
                servodriver.servo[numservo].angle = None
            except Exception:
                pass
    except Exception as e:
        print(f"FError controlling servos: {e}")

def handle_exit(signum, frame): # signum, frame needed to call via signal.signal
    print("Exiting. Please wait", end="\r")
    IdleMode()
    stop_event.set() # set the thread-flag to stop starting new threads
    Servotestdriver.stop_servo_test()
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
        LGCDdriver.shutdown()
        Servotestdriver.shutdown_test()
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
        IdleMode() # in case the client closes connection
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

            angleLC = receivedData[LC]
            angleRC = receivedData[RC]
            angleLO = receivedData[LO]
            angleRO = receivedData[RO]
            angleAB = receivedData[AB]
            angleLF = receivedData[LF]
            angleRF = receivedData[RF]
            fractionLG = receivedData[LG] # 0 is min, 1 max pulsewidth (LG dooesnt need in beteen)

            print(threading.active_count(), "threads")

            if receivedData[MODE] == 0:
                Servotestdriver.stop_servo_test()
                print("IdleMode")
                IdleMode()

            elif receivedData[MODE] == 1:
                Servotestdriver.stop_servo_test()
                print("Remote-Mode")
                # map fraction to LG state and request it (last-value buffer)
                state = fractionLG
                LGCDdriver.request_lg(state)
                PWMsetServo_EF()

            elif receivedData[MODE] == 2:
                print("Servotest")
                Servotestdriver.start_servo_test()
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