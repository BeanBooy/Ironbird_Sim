import time
from adafruit_servokit import ServoKit

# Initialisiere das ServoKit-Objekt mit der I2C-Adresse 0x41
channel = 12
kit = ServoKit(channels=16, address=0x40,frequency=30)

#LG = ServoKit(channels=16, address=0x41,frequency=30)
#kit.servo[channel].set_pulse_width_range(500,2250)
kit.servo[channel].set_pulse_width_range(1000,2000)
# Setze die minimale und maximale Position des Servos
min_position = 0  # Minimal Position
max_position = 180  # Maximale Position

# Schrittgröße für die Bewegung des Servos
step_size = 10

# Zeitverzögerung zwischen den Schritten (in Sekunden)
#delay = 0.003

# delay per step = time in seconds/stepscount



def delay(seconds, steps_difference):
        delay = seconds/steps_difference
        return delay

#for angle in range(0,180):
#    kit.servo[channel].angle = angle
#    time.sleep(delay(10,180))
#time.sleep(0.5)
#kit.servo[channel].angle = 0
#time.sleep(2)
#kit.servo[channel].angle = None
for i in range (10,1):
    print(i)


