import sys
import signal
import socket
import argparse
import time
from adafruit_servokit import ServoKit



# adresses of Landinggear and digital Servos
I2CSERVO = 0x40
I2CLG = 0x41
LG_OUT = 1
LG_IN = 0
delay = 6 # Delay in seconds for LG-Sequence

# TCP-Port
PORT_CONST = 4443

MODE = 0
LC = 1  # Left Canards
RC = 2  # Right Canards
LO = 3  # Left Aileron (Outboard, Querruder)
RO = 4  # Right Aileron
AB = 5 # Airbrakes
LF = 6	# Flaps Inboard
RF = 7 # Flaps Outboard
LG = 8 # Landing Gear

# Angles

angleLC = 0
angleRC = 0
angleLO = 0
angleRO = 0
angleAB = 0
angleLF = 0
angleRF = 0
fractionLG = 0

try:
    # initialize socket
    HOST = '' # '' represents INADDR_ANY, which is used to bind to all interfaces -> We are the Server, we receive
    PORT = PORT_CONST
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((HOST, PORT))
    server_socket.listen(5) # 5 equals to 5 connection-tests. aftwerwards the server refuses to connect
    print(f"Server waits for {HOST}:{PORT}")

except Exception as e:
    print(f"Server could not be started: {e}")
    exit(1)

# cleans sockets and ends the programm
def handle_exit(signum, frame):
    print("Disconecting...")
    if 'client_socket' in globals() and client_socket is not None:
        client_socket.close()
    if 'server_socket' in globals() and server_socket is not None:
        server_socket.close()
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
            LGdriver.servo[0].fraction = LG_OUT
            time.sleep(delay)
        elif state == LG_IN:
            LGdriver.servo[0].fraction = LG_IN
            time.sleep(delay)
        elif state == None:
            LGdriver.servo[0].fraction = None
        
    def move(self,servo,angle,pause=True):
        if isinstance(servo, int): # if only one channel given: channel -> list of channel(s)
            servo = [servo]
        for channel in servo:
            #servodriver.servo[channel].set_pulse_width_range(1000, 2000)
            servodriver.servo[channel].angle = angle
        if pause == True:
          time.sleep(delay/2)

LG = Servo("LandingGear")       # Initialize Classobjects
CD = Servo("CabinDoor")

def LGCD_sequence(channels,state):
    if state == LG_OUT:
        if isinstance(channels, int):
           channels = [channels]

        # open CD for selected channels

        for channel in channels:
           print("Servochannel ", channel," | to angle 0")
           CD.move(channel,180,False)
        time.sleep(delay/2)

        print("LG Out")
        LG.move_LG(LG_OUT) # after CD open LG

    elif state == LG_IN:

        print("LG IN") # First close LG
        LG.move_LG(LG_IN)

        for channel in channels:
           print("Servochannel ", channels," | to angle 0")
           CD.move(channel,90,False)
        time.sleep(delay/2)
        print("ERFOLG!!!")
        


def setpulsewidth():
    for channel in range(16):
            servodriver.servo[channel].set_pulse_width_range(1000,2000)

def signaltoangle(signal): # received signal in range from 0 to 256 convert to angle
    angle = int(signal * 0.703125)
    return angle

# Servos in die vorgegebene Position fahren
def PWMsetServo_EF():
    try:
        servodriver.servo[0].angle = 90
        servodriver.servo[1].angle = signaltoangle(angleLC)
        servodriver.servo[2].angle = signaltoangle(angleRC)
        servodriver.servo[3].angle = signaltoangle(angleLO)
        servodriver.servo[4].angle = signaltoangle(angleRO)
        servodriver.servo[5].angle = signaltoangle(angleAB)
        servodriver.servo[6].angle = signaltoangle(angleLF)
        servodriver.servo[7].angle = signaltoangle(angleRF)
        servodriver.servo[8].angle = 90
        servodriver.servo[9].angle = 90
        servodriver.servo[10].angle = 90
        servodriver.servo[11].angle = 90
        
        servodriver.servo[12].angle = 90 # Triebwerksbeleuchtung (beide an Port 12)
        servodriver.servo[13].angle = 90 # Laserpointer

        servodriver.servo[14].angle = 90 # Horizontal
        servodriver.servo[15].angle = 90 # Vertikal

        LGCD_sequence([0,1,2],fractionLG)

    except Exception as e:
        print(f"(EF) Fehler beim Ansteuern der Servos: {e}")



def RuheModus():
    try:
        for numservo in range(16):
            servodriver.servo[numservo].angle = 0
            servodriver.servo[numservo].angle = None # detach all Servos
        LGCD_sequence([0,1,2],LG_IN)
    except Exception as e:
        print(f"Fehler beim Ansteuern der Servos: {e}")

def ServoTest():
    for cylce in range(2):
        for angle in range(0, 180):
            for servoNum in range(0, 16):
                servodriver.servo[servoNum].angle = angle
                time.sleep(0.5)
        LGCD_sequence([0,1,2],LG_OUT)
        RuheModus()

#-------------------------------------------------------------------------------------------------------------------
# Main Loop

signal.signal(signal.SIGINT, handle_exit) # signal-handling for STRG+C (ends Software correctly)

while True:
    try:
        print("Wait for Connection...")
        client_socket, addr = server_socket.accept() #succsesfull connected to server
        print(f"Connected to {addr} succesfull")

    except Exception as e:
        print(f"Connection cannot be established: {e}")
        exit(1)
    setpulsewidth() # only important for digital Servos used in this project
    while True:
        receivedData = client_socket.recv(32)
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
        fractionLGLG = receivedData[LG]
        

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
        elif receivedData[MODE] == 2:  # RemoteModus, Servos fahren (schnell) in Position
            print("Remote-Mode")
            PWMsetServo_EF()
        elif receivedData[MODE] == 3:   # Servotest
            print("Servotest")
            ServoTest()
        elif receivedData[MODE] > 3 or receivedData[MODE] < 0:
            print("Received cooruped data")
            RuheModus()

    client_socket.close()