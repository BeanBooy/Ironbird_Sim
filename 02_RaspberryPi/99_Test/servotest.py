import time
from adafruit_servokit import ServoKit

# Initialisiere das ServoKit-Objekt mit der I2C-Adresse 0x41
channel = 0
kit = ServoKit(channels=16, address=0x41,frequency=30)



# Setze die minimale und maximale Position des Servos
min_position = 0  # Minimal Position
max_position = 180  # Maximale Position

# Schrittgröße für die Bewegung des Servos
step_size = 10

# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 1

# Funktion zum Bewegen des Servos von min_position zu max_position
def move_servo(angle):
        kit.servo[channel].fraction = 1
        time.sleep(delay)

try:

    kit.servo[channel].fraction = 1
    time.sleep(6)
    kit.servo[channel].fraction= 0

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    kit.servo[channel].angle = 90

