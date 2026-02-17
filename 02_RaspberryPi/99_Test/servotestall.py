import time
from adafruit_servokit import ServoKit

# Initialisiere das ServoKit-Objekt mit der I2C-Adresse 0x40 (Default)
dServo = ServoKit(channels=16, address=0x40,frequency=333) # frequency 333Hz ONLY for DIGITAL SERVOS!
LGServo = ServoKit(channels=16, address=0x41, frequency=30) # Landing Gear, only min or max (optional: Use Flightcontroller)

# Setze die minimale und maximale Position des Servos
min_position = 0
max_position = 180 
mid_position = (max_position+min_position) / 2

positions = [min_position,mid_position,max_position]
LGchannel = [14,15] # at least for testing (only two, because MLG is controlled as one)

# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 0.5

# Jeden Servo einzeln hintereinander auf min, mid, max setzen

def test_dServo():
    def move_dServo(servo, angle):
        dServo.servo[servo].angle = angle
        time.sleep(delay)
    for servo in range(dServo._channels): # goes through all channels and tests every servo for min, mid, max position
            if servo not in LGchannel:
                for angle in range(len(positions)):
                    move_dServo(servo,int(positions[angle]))

def test_LG():
    def move_LGServo(servo, LG_state):
        LGServo.servo[servo].angle = LG_state
        time.sleep(3)
    for LG in range(len(LGchannel)):
        move_LGServo(LGchannel[LG],max_position)
        move_LGServo(LGchannel[LG],min_position)


try:
    while True:
        test_LG()
        test_dServo()
        

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    for servo in range(len(dServo.servo)):
            if servo in LGchannel:
                 LGServo.servo[servo].angle = min_position
            else:
                 dServo.servo[servo].angle = mid_position
