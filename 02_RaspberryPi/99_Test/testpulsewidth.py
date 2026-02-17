import time
from adafruit_servokit import ServoKit

kit = ServoKit(channels=16, address=0x40, frequency=300)

# MD31092: Mitte = 2000 µs → Range 1000–3000 µs
kit.servo[0].set_pulse_width_range(1400, 2600)

while True:
    kit.servo[0].angle = 0
    time.sleep(2)
    kit.servo[0].angle = 45
    time.sleep(2)
    kit.servo[0].angle = 90
    time.sleep(2)
    kit.servo[0].angle = 135
    time.sleep(2)
    kit.servo[0].angle = 180
    time.sleep(2)