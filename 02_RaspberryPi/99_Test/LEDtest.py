import time
from adafruit_servokit import ServoKit

Servo = ServoKit(channels=16, address=0x40, frequency=330) # uses same frequency as LG


# max und min lightdensity equals on and o
Servo.servo[0].set_pulse_width_range(1000,2000)
Servo.servo[0].actuation_range = 180
# Zeitverzögerung zwischen den Schritten (in Sekunden)


# Jeden Servo einzeln hintereinander auf min, mid, max setzen



try:
    print(Servo.servo[0]._pwm_out)
    Servo.servo[0].angle = 180
    time.sleep(3)
    print(Servo.servo[0]._pwm_out)
    Servo.servo[0].angle = 90
    time.sleep(3)
    print(Servo.servo[0]._pwm_out)
    Servo.servo[0].angle = 0
    time.sleep(3)
        

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    print("error")

