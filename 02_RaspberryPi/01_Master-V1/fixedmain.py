import sys
import signal
import socket
import argparse
import threading
import time
import LGdriver
from LGdriver import LG_IN, LG_OUT, LG_INMOTION, safe_sleep, stop_event, oldstate
from adafruit_servokit import ServoKit



# adresses of Landinggear and digital Servos
I2CSERVO = 0x40
I2CLG = 0x41

current_thread = None # thread lags for LG
current_event = None


delay = 6 # Delay in seconds for LG-Sequence

#stop_thread = threading.Event() # set flag for threads to handle exit
lg_lock = threading.Lock() # threads dont interrupt each other


# TCP-Port
PORT_CONST = 4443

MODE = 0 # equals idle

# signal 1 - 3 reserved for Cabindoor
LC = 1  # Left Canards
RC = 2  # Right Canards
LO = 3  # Left Aileron (Outboard, Querruder)
RO = 4  # Right Aileron
LF = 5	# Flaps Inboard
RF = 6 # Flaps Outboard
AB = 7 # Airbrakes
LG = 8 # Landing Gear

# Angles

angleLC = 128 # as one byte signal, equals 90 degrees later on
angleRC = 128
angleLO = 128
angleRO = 128
angleAB = 128
angleLF = 128
angleRF = 128
fractionLG = LG_IN



try:
    # initialize socket
    HOST = '' # '' represents INADDR_ANY, which is used to bind to all interfaces -> We are the Server, we receive
    PORT = PORT_CONST
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server_socket.bind((HOST, PORT))
    server_socket.listen(5) # 5 equals to 5 connection-tests. aftwerwards the server refuses to connect
    print(f"Server waits for {HOST}:{PORT}")

except Exception as e:
    print(f"Server could not be started: {e}")
    exit(1)


def start_thread(target, *args):
    global current_thread, current_event

    # dont start a new thread
    if current_thread is not None and current_thread.is_alive():
        return current_thread

    # stop old threads
    if current_event is not None:
        current_event.set()

    current_event = threading.Event()

    # start a new thread
    t = threading.Thread(target=target, args=(current_event, *args))
    t.start()

    current_thread = t
    return t



# cleans sockets and ends the programm
def handle_exit(signum, frame):
    print("Exiting. Please wait",end="\r")
    RuheModus()

   #if current_event is not None: # softly closes remaining threads
        #current_event.set()
    
    #if current_thread is not None and current_event.is_set():
        #current_thread.join(timeout=1)

    if 'client_socket' in globals() and client_socket is not None:
        client_socket.close()
    if 'server_socket' in globals() and server_socket is not None:
        server_socket.close()
    LGdriver.shutdown()
    print(f"Disconnected successfully".ljust(50))
    sys.exit(0)

try:
    servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=333) # Declare frequenzy for PWM-signals (Only use for digital Servos except Landing Gear)
    

except Exception as e:
    print(f"(SERVO) ServoKit could not be initialized: {e}")

try:
    LGdriver.initLG()

except Exception as e:
    print(f"(LG) ServoKit could not be initialized: {e}")



def setpulsewidth():
    for channel in range(16):
            servodriver.servo[channel].set_pulse_width_range(1000,2000)

def signaltoangle(signal): # received signal in range from 0 to 256 convert to angle
    angle = int(signal * 0.703125)
    return angle

# Servos in die vorgegebene Position fahren
def PWMsetServo_EF():
    try:
        # channel 0 - 2 reserved for cabindoors
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
        
        servodriver.servo[15].angle = 90 # Triebwerksbeleuchtung (beide an Port 12)

        #LGdriver.start_LGCD_thread([0,1,2],fractionLG,servodriver)
    except Exception as e:
        print(f"(EF) Fehler beim Ansteuern der Servos: {e}")



def RuheModus():
    try:
        for numservo in range(3,16):
            servodriver.servo[numservo].angle = 90
        LGdriver.start_LGCD_thread([0,1,2],LG_IN,servodriver)
        safe_sleep(delay)
        for numservo in range(3):   # set CD default
            servodriver.servo[numservo].angle = 90
        for numservo in range(16):
            servodriver.servo[numservo].angle = None # detach all Servos
        LGdriver.start_LGCD_thread([0,1,2],None,servodriver)
        safe_sleep(delay)

    except Exception as e:
        print(f"Fehler beim Ansteuern der Servos: {e}")

def ServoTest():
    while receivedData[MODE] == 3:
        for cylce in range(2):
            for angle in range(0, 180):
                for servoNum in range(0, 16):
                    servodriver.servo[servoNum].angle = angle
                    safe_sleep(0.5)

            # Beispiel: LG ausfahren während Test
            LGdriver.start_LGCD_thread([0,1,2],LG_OUT,servodriver)
        RuheModus()

#-------------------------------------------------------------------------------------------------------------------
# Main Loop

signal.signal(signal.SIGINT, handle_exit) # signal-handling for STRG+C (ends Software correctly)

while not stop_event.is_set():
    try:
        print("Wait for Connection...")
        client_socket, addr = server_socket.accept() #succsesfull connected to server
        print(f"Connected to {addr} succesfull")

    except Exception as e:
        print(f"Connection cannot be established: {e}")
        exit(1)
    setpulsewidth() # only important for digital Servos used in this project
    while True:
        receivedData = client_socket.recv(16) # We receive 16 bytes
        if not receivedData:
            break

        printData = ','.join(str(byte) for byte in receivedData)
        print(f"Received data: {printData}")

        # received angles in range 0 to 256, will be transformed to degrees later
        angleLC = receivedData[LC]
        angleRC = receivedData[RC]
        angleLO = receivedData[LO]
        angleRO = receivedData[RO]
        angleAB = receivedData[AB]
        angleLF = receivedData[LF]
        angleRF = receivedData[RF]
        fractionLG = receivedData[LG]

        print(threading.active_count(), "threads")

        if receivedData[MODE] == 0: # Aus / RuheModus
            print("RuheModus")
            RuheModus()

        # NOTE: Showmodus entfernt, da nicht mehr benoetigt
        #        elif receivedData[MODE] == 1: # Showmodus, Servos fahren langsam in Position
        #           print("Showmodus")
        #           #PWMsetServo_EF_SLOW()
        #           PWMsetLEDs()

        #elif receivedData[MODE] == 1:
            #print("LED-Steuerung")
            #PWMsetLEDs()
        elif receivedData[MODE] == 1:  # RemoteModus, Servos fahren (schnell) in Position
            print("Remote-Mode")
            LGdriver.start_LGCD_thread([0,1,2],fractionLG,servodriver)
            PWMsetServo_EF()
        elif receivedData[MODE] == 3:   # Servotest
            print("Servotest")
            ServoTest()
        elif receivedData[MODE] > 3 or receivedData[MODE] < 0:
            print("Received cooruped data")
            RuheModus()

    client_socket.close()