import time
from adafruit_servokit import ServoKit

# Initialisiere das ServoKit-Objekt mit der I2C-Adresse 0x40 (Default)
dServo = ServoKit(channels=16, address=0x40,frequency=333) # frequency 33Hz ONLY for DIGITAL SERVOS!

# Setze die minimale und maximale Position des Servos
min_position = 0  # Minimal Position
max_position = 180  # Maximale Position
mid_position = (max_position+min_position) / 2

positions = [min_position,mid_position,max_position]

# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 0.2

# Jeden Servo einzeln hintereinander auf min, mid, max setzen

def move_dServo(i, angle):
    dServo.servo[i].angle = angle
    time.sleep(delay)

try:
    while True:
        for servo in range(dServo._channels):
            for angle in range(len(positions)):
                move_dServo(servo,positions[angle])

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    for servo in range(dServo._channels):
            move_dServo(servo,mid_position)
