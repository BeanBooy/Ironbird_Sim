import time
from adafruit_servokit import ServoKit

LED = ServoKit(channels=16, address=0x41, frequency=30) # uses same frequency as LG


# max und min lightdensity equals on and off
led_off = 0
led_on = 180 


# Zeitverzögerung zwischen den Schritten (in Sekunden)
delay = 0.1

# Jeden Servo einzeln hintereinander auf min, mid, max setzen



try:
    while True:
        LED.servo[15].angle = led_off
        

except KeyboardInterrupt:
    # Wenn CTRL+C gedrückt wird, stoppe die Bewegung und setze den Servo auf 90 Grad
    print("error")

