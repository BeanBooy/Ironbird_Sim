import time
from adafruit_servokit import ServoKit

LGServo = ServoKit(channels=16, address=0x41, frequency=30) # Landing Gear, only min or max (optional: Use Flightcontroller)
# cant use LG Servo here because LGservo needs different board (cant controll two diffenrent types of Servos (frequencys) on one board)

# Setze die minimale und maximale Position des Servos
min_position = 0
max_position = 180 


# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 10

# Jeden Servo einzeln hintereinander auf min, mid, max setzen



try:
    i = 0
    while i < 1:
        LGServo.servo[0].angle = 180
        LGServo.servo[1].angle = 180
        time.sleep(delay)
        LGServo.servo[0].angle = 0
        LGServo.servo[1].angle = 0
        time.sleep(delay)
        i += 1
    LGServo.servo[0].angle = None
    LGServo.servo[1].angle = None
        

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    LGServo.servo[0].angle = 0
    LGServo.servo[1].angle = 0
    time.sleep(delay)
    LGServo.servo[0].angle = None
    LGServo.servo[1].angle = None