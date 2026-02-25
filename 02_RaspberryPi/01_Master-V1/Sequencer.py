import LGCDdriver
from adafruit_servokit import ServoKit
from LGCDdriver import LG_IN, LG_OUT, safe_sleep, stop_event

servodriver = ServoKit(channels=16,address=0x40,frequency=30)

LC = 3  # Left Canards
RC = 4  # Right Canards
LO = 5  # Left Aileron (Outboard, Querruder)
RO = 6  # Right Aileron
LF = 7	# Flaps Inboard
RF = 8 # Flaps Outboard
AB = 9 # Airbrakes
LG = 15 # Landing Gear

class Servo:
    def __init__(self):
        self.channel = None
        self.angle = None
        self.idle = None
        self.pulsewidth = servodriver.servo[self.channel].set_pulse_width_range(1000,2000)
        self.actuation_range = servodriver.servo[self.channel].actuation_range = 180

    def move(self):
        servodriver.servo[self.channel].angle = self.angle
    
    def set_idle(self):
        servodriver.servo[self.channel].angle = self.idle

