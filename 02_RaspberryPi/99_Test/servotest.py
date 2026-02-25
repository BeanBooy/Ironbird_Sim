import time
from adafruit_servokit import ServoKit

# Initialisiere das ServoKit-Objekt mit der I2C-Adresse 0x41
channel = 0
kit = ServoKit(channels=16, address=0x40,frequency=30)

#LG = ServoKit(channels=16, address=0x41,frequency=30)
for channel in range(16):
            kit.servo[channel].set_pulse_width_range(1000,2000)
# Setze die minimale und maximale Position des Servos
min_position = 0  # Minimal Position
max_position = 180  # Maximale Position

# Schrittgröße für die Bewegung des Servos
step_size = 10

# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 6

# Funktion zum Bewegen des Servos von min_position zu max_position
def move_servo(angle):
        print("moving")
        kit.servo[channel].angle = angle
        #LG.servo[0].fraction = 1
        time.sleep(delay)

try:

    kit.servo[15].angle = 180
    time.sleep(3)
    kit.servo[15].angle = 0
    time.sleep(3)
 

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    kit.servo[channel].angle = 0

