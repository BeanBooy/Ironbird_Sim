from adafruit_servokit import ServoKit
import time

delay = 6 # time to wait before pwm signal ends in seconds

Servos = ServoKit(channels=16,address=0x40,frequency=333)
LaG = ServoKit(channels=16,address=0x41,frequency=30)
LG_OUT = 1
LG_IN = 0

class Servo():
    def __init__(self, name):
        self.name = name
        
    def move_LG(self, state):
        if state == LG_OUT:
            LaG.servo[0].fraction = LG_OUT
            time.sleep(delay)
        elif state == LG_IN:
            LaG.servo[0].fraction = LG_IN
            time.sleep(delay)
        
    def move_CD(self,servo,angle):
        Servos.servo[servo].set_pulse_width_range(1000,2000)
        Servos.servo[servo].angle = angle
        time.sleep(delay/2)
        
    def inverServ(self,servo,angle, Kit=Servos):
        Kit.servo[servo].angle = int(180-angle)

LG = Servo("LandingGear")       # Initialize Classobjects
CD = Servo("CabinDoor")

def idle():
    CD.move_CD(0,90)
    CD.move_CD(1,90)
    LG.move_LG(LG_IN)
    time.sleep(delay)


LG.move_LG(LG_OUT)
LG.move_LG(LG_IN)
CD.move_CD(0,0)
CD.move_CD(0,90)
CD.move_CD(0,180)

idle()

