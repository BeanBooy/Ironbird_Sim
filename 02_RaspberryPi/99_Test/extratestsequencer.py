from gpiozero import AngularServo
from time import sleep
s = AngularServo(17, min_angle=0, max_angle=180)


while True:
    s.min()
    sleep(1)
    s.mid()
    sleep(1)
    s.max()
    sleep(1)
