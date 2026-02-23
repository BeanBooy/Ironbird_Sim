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
        elif state == None:
            LaG.servo[0].fraction = None
        
    def move(self,servo,angle,pause=True):
        if isinstance(servo, int): # if only one channel given: channel -> list of channel(s)
            servo = [servo]
        for channel in servo:
            Servos.servo[channel].set_pulse_width_range(1000, 2000)
            Servos.servo[channel].angle = angle
        if pause == True:
          time.sleep(delay/2)
        
    def inverServ(self,servo,angle, Kit=Servos):
        Kit.servo[servo].angle = int(180-angle)

LG = Servo("LandingGear")       # Initialize Classobjects
CD = Servo("CabinDoor")

def idle():
    CD.move([0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],90,False) # just reset every channel
    LG.move_LG(LG_IN)
    time.sleep(delay)
    CD.move([0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15],None,False)
    LG.move_LG(None)

def LGCD_sequence(channels,state):
    if state == LG_OUT:
        if isinstance(channels, int):
           channels = [channels]

        # open CD for selected channels

        for channel in channels:
           print("Servochannel ", channel," | to angle 0")
           CD.move(channel,180,False)
        time.sleep(delay/2)

        print("LG Out")
        LG.move_LG(LG_OUT) # after CD open LG
        #time.sleep(delay)
    elif state == LG_IN:

        print("LG IN") # First close LG
        LG.move_LG(LG_IN)
        time.sleep(delay)
        for channel in channels:
           print("Servochannel ", channels," | to angle 0")
           CD.move(channel,0,False)
        time.sleep(delay/2)
        print("ERFOLG!!!")
        


LGCD_sequence([0,1,2],LG_IN)
time.sleep(delay)
print("Out erfolgreich, jetzt 3 sek warten")
idle()



