import sys
import signal
import socket
import argparse
import threading
import time
from adafruit_servokit import ServoKit



# adresses of Landinggear and digital Servos
I2CSERVO = 0x40
I2CLG = 0x41
LG_OUT = 2
LG_IN = 1
delay = 6 # Delay in seconds for LG-Sequence
stop_thread = threading.Event() # set flag for threads to handle exit

# TCP-Port
PORT_CONST = 4443

MODE = 0 # equals idle

# signal 1 - 3 reserved for Cabindoor
LC = 4  # Left Canards
RC = 5  # Right Canards
LO = 6  # Left Aileron (Outboard, Querruder)
RO = 7  # Right Aileron
AB = 8 # Airbrakes
LF = 9	# Flaps Inboard
RF = 10 # Flaps Outboard
LG = 11 # Landing Gear

# Angles

angleLC = 0
angleRC = 0
angleLO = 0
angleRO = 0
angleAB = 0
angleLF = 0
angleRF = 0
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

def safe_sleep(seconds):
     for i in range(int(seconds * 10)): 
        if stop_thread.is_set(): 
            return 
        time.sleep(0.1)

threads = [] # collect all threads to end them simultaniously
def start_thread(target, *args): 
    t = threading.Thread(target=target, args=args) 
    t.start()
    threads.append(t) 
    return t

# cleans sockets and ends the programm
def handle_exit(signum, frame):
    print("Disconecting...")
    stop_thread.set() # handling threads

    for t in threads:
        print(f"Ending thread {t}")
        t.join(timeout=1)

    if 'client_socket' in globals() and client_socket is not None:
        client_socket.close()
    if 'server_socket' in globals() and server_socket is not None:
        server_socket.close()
    RuheModus()
    sys.exit(0)

try:
    servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=333) # Declare frequenzy for PWM-signals (Only use for digital Servos except Landing Gear)
    

except Exception as e:
    print(f"(SERVO) ServoKit could not be initialized: {e}")

try:
    #Initialisierung des ServoKit-Objekts fuer die LEDs TODO: Adresse anpassen
    LGdriver = ServoKit(channels=16,address=I2CLG,frequency=30)

except Exception as e:
    print(f"(LG) ServoKit could not be initialized: {e}")



class Servo():
    def __init__(self, name):
        self.name = name

    def move_LG(self, state):
        if state == LG_OUT:
            LGdriver.servo[0].fraction = 1
            safe_sleep(delay)
        elif state == LG_IN:
            LGdriver.servo[0].fraction = 0
            safe_sleep(delay)
        elif state == None:
            LGdriver.servo[0].fraction = None
        
    def move(self,servo,angle,pause=True):
        if isinstance(servo, int): # if only one channel given: channel -> list of channel(s)
            servo = [servo]
        for channel in servo:
            #servodriver.servo[channel].set_pulse_width_range(1000, 2000)
            servodriver.servo[channel].angle = angle
        if pause == True:
          safe_sleep(delay/2)

LaG = Servo("LandingGear")       # Initialize Classobjects
CaD = Servo("CabinDoor")

def LGCD_sequence(channels,state):
    if stop_thread.is_set():
        return
    if state == LG_OUT:
        if isinstance(channels, int):
           channels = [channels]

        # open CD for selected channels

        for channel in channels:
           CaD.move(channel,180,False)
        safe_sleep(delay/2)

        #print("LG Out")
        LaG.move_LG(LG_OUT) # after CD open LG

    elif state == LG_IN:
        # First close LG
        #print("LG IN") 
        LaG.move_LG(LG_IN)

        for channel in channels:
           CaD.move(channel,90,False)
        safe_sleep(delay/2)
        #print("ERFOLG!!!")
        


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

        start_thread(LGCD_sequence, [0,1,2], fractionLG)

    except Exception as e:
        print(f"(EF) Fehler beim Ansteuern der Servos: {e}")



def RuheModus():
    try:
        for numservo in range(3,16):
            servodriver.servo[numservo].angle = 90
        LGdriver.servo[0].fraction = 0
        safe_sleep(delay)
        CaD.move([0,1,2],90,False)
        for numservo in range(3,16):
            servodriver.servo[numservo].angle = None # detach all Servos
        LGdriver.servo[0].fraction = None
        safe_sleep(delay)
        CaD.move([0,1,2],None,False)


    except Exception as e:
        print(f"Fehler beim Ansteuern der Servos: {e}")

def ServoTest():
    while receivedData[MODE] == 3 and not stop_thread.is_set():
        for cylce in range(2):
            for angle in range(0, 180):
                for servoNum in range(0, 16):
                    servodriver.servo[servoNum].angle = angle
                    safe_sleep(0.5)
            if start_thread.is_set():
                start_thread(LGCD_sequence, [0,1,2], LG_OUT)
            RuheModus()

#-------------------------------------------------------------------------------------------------------------------
# Main Loop

signal.signal(signal.SIGINT, handle_exit) # signal-handling for STRG+C (ends Software correctly)

while not stop_thread.is_set():
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

        # Save received angles in range 0 to 256, will be transformed to degrees later
        angleLC = receivedData[LC]
        angleRC = receivedData[RC]
        angleLO = receivedData[LO]
        angleRO = receivedData[RO]
        angleAB = receivedData[AB]
        angleLF = receivedData[LF]
        angleRF = receivedData[RF]
        fractionLG = receivedData[LG]
        

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
            PWMsetServo_EF()
        elif receivedData[MODE] == 3:   # Servotest
            print("Servotest")
            ServoTest()
        elif receivedData[MODE] > 3 or receivedData[MODE] < 0:
            print("Received cooruped data")
            RuheModus()

    client_socket.close()