import LGCDdriver
from adafruit_servokit import ServoKit
import time
from LGCDdriver import LG_IN, LG_OUT, safe_sleep, stop_event

servodriver = ServoKit(channels=16,address=0x40,frequency=30)


class Servo:
    def __init__(self, channel, idle, actuation_range = 180, min_pulsewidth = 1000, max_pulsewidth = 2000, inverted = False):
        self.channel = channel
        self.idle = idle
        self.inverted = inverted
        self.min_pos = 0
        self.max_pos = actuation_range
        self.mid_pos = int(self.max_pos/2)
        self.current_pos = idle
        self.min_pulsewidth = min_pulsewidth
        self.max_pulsewidth = max_pulsewidth
        self.pulsewidth = servodriver.servo[self.channel].set_pulse_width_range(self.min_pulsewidth, self.max_pulsewidth)

    def signal_inverter(self,receivedDATA):
        angle = (180 - receivedDATA)
        return angle
    
    def move(self, angle, seconds=1):
        start = self.current_pos
        end = angle
        step = 1
        steps = end-start

        if start > end:
            step = -1
        if steps == 0:
            return

        delay = seconds/steps
        if delay < 0:
            delay *= -1


        if self.inverted == True:
            for angle in range(start,end,step):
                servodriver.servo[self.channel].angle = self.signal_inverter(angle)
                #time.sleep(delay)
        else:
            for angle in range(start,end,step):
                servodriver.servo[self.channel].angle = angle
                #time.sleep(delay)

        self.current_pos = end
        #time.sleep(1)

#LC = 3  # Left Canards
#RC = 4  # Right Canards
#LO = 5  # Left Aileron (Outboard, Querruder)
#RO = 6  # Right Aileron
#LF = 7	# Left Flaps
#RF = 8 # Right Flaps
#AB = 9 # Airbrakes
#LG = 15 # Landing Gear

LC = Servo(channel=3,idle=90)
RC = Servo(channel=4,idle=90)
LO = Servo(channel=5,idle=90)
RO = Servo(channel=6,idle=90)
LF = Servo(channel=7,idle=90)
RF = Servo(channel=8,idle=90)
AB = Servo(channel=9,idle=0)
LG = Servo(channel=15,idle=0,min_pulsewidth=500, max_pulsewidth=2250)

for angle in range(180):
    LC.move(angle)
    RC.move(angle)
    LO.move(angle)
    RO.move(angle)
    LF.move(angle)
    RF.move(angle)
    AB.move(angle)
    #time.sleep(0.005)

for angle in range(180,0,-1):
    LC.move(angle)
    RC.move(angle)
    LO.move(angle)
    RO.move(angle)
    LF.move(angle)
    RF.move(angle)
    AB.move(angle)
    #time.sleep(0.005)
