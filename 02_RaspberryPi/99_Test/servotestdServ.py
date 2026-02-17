import time
from adafruit_servokit import ServoKit

# Initialisiere das ServoKit-Objekt mit der I2C-Adresse 0x40 (Default)
dServo = ServoKit(channels=16, address=0x40,frequency=333) # frequency 300-333Hz ONLY for DIGITAL SERVOS!


# Setze die minimale und maximale Position des Servos
min_position = 0
max_position = 180 
mid_position = int((max_position+min_position) / 2)

positions = [min_position,mid_position,max_position]
#channelsOccupied = [0,5,9,12] # can be deleted if you want to go through every channel (here only for testingpurpose)

# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 2

# set Pulsewidth like described in README.md 
try:
    for channel in range(len(channelsOccupied)):
        dServo.servo[channelsOccupied[channel]].set_pulse_width_range(1400, 2600)
except:
    for channel in range(dServo._channels):
         dServo.servo[channel].set_pulse_width_range(1400,2600)

# Jeden Servo einzeln hintereinander auf min, mid, max setzen


def move_dServo(servo, angle):
    dServo.servo[servo].angle = angle
    time.sleep(delay)

def test_dServo():
    try:
        for channel in range(len(channelsOccupied)):
                for angle in range(len(positions)):
                    move_dServo(channelsOccupied[channel],positions[angle])
    except:
        for servo in range(dServo._channels):
                for angle in range(len(positions)):
                    move_dServo(servo,positions[angle])

def idle_dServo():
     dServo.servo[0].angle = 90
     dServo.servo[1].angle = 90
     dServo.servo[2].angle = 90
     dServo.servo[3].angle = 90
     dServo.servo[4].angle = 90
     dServo.servo[5].angle = 90
     dServo.servo[6].angle = 90
     dServo.servo[7].angle = 90
     dServo.servo[8].angle = 90
     dServo.servo[9].angle = 90
     dServo.servo[10].angle = 90
     dServo.servo[11].angle = 90
     dServo.servo[12].angle = 90
     dServo.servo[13].angle = 90
     dServo.servo[14].angle = 90
     dServo.servo[15].angle = 90
     time.sleep(5)
     for servo in range(16):
          dServo.servo[servo].angle = None

# Main loop
try:
    i = 0
    #idle_dServo()
    while i < 1:
        test_dServo()
        i += 1
    idle_dServo()

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    idle_dServo()

