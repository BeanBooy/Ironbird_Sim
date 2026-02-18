import time
from adafruit_servokit import ServoKit

# Initialisiere das ServoKit-Objekt mit der I2C-Adresse 0x41
kit = ServoKit(channels=16, address=0x41,frequency=333)
kit.servo[15].set_pulse_width_range(1400,2600)
# Setze die minimale und maximale Position des Servos
min_position = 0  # Minimal Position
max_position = 180  # Maximale Position

# Schrittgröße für die Bewegung des Servos
step_size = 1

# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 0.2

# Funktion zum Bewegen des Servos von min_position zu max_position
def move_servo():
    for angle in range(min_position, max_position + 1, step_size):
        kit.servo[15].angle = angle
        time.sleep(delay)

    for angle in range(max_position, min_position - 1, -step_size):
        kit.servo[15].angle = angle
        time.sleep(delay)

try:
    while True:
        move_servo()

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    kit.servo[15].angle = 90