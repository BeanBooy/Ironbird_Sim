from adafruit_servokit import ServoKit

servodriver = ServoKit(channels=16,address=0x40,frequency=50)


class Servo:
    def __init__(self, channel, idle, min_pos=0, max_pos=256, actuation_range=256, min_pulsewidth=1000, max_pulsewidth=2300, inverted=False):
        # NOTE: Please remember actuation range in this case 256 because received data isnt 0 to 180 but 0 to 256.
        #       max_pos ca be changed to limit the real range
        self.channel = channel
        self.idle = idle
        self.inverted = inverted
        self.min_pos = min_pos
        if max_pos != actuation_range:
            self.max_pos = max_pos
        else:
            self.max_pos = actuation_range
        self.mid_pos = int(self.max_pos/2)
        self.current_pos = idle
        self.pulsewidth = servodriver.servo[self.channel].set_pulse_width_range(min_pulsewidth, max_pulsewidth)
        servodriver.servo[self.channel].actuation_range = actuation_range

    def signal_inverter(self,receivedDATA):
        angle = (256 - receivedDATA)
        return angle
    
    def map_input(self, value):
        # gives back correct servovalues, if max or an min values are set
        return int(self.min_pos + (value / 255) * (self.max_pos - self.min_pos))
    
    def move(self, raw_angle):
        if raw_angle == None: # detach servo, nothing more
            servodriver.servo[self.channel].angle = None
            return

        #angle = int(angle*0.703125) # NOTE: from 0 to 256 -> 0° to 180°

        raw_angle = max(0, min(255, raw_angle)) # to be sure
        #if raw_angle == self.idle:
            #angle = self.idle
        #else:
           #angle = self.map_input(raw_angle)
        angle = self.map_input(raw_angle)
        if angle == self.current_pos:
            return

        end = angle

        if self.inverted == True:
            servodriver.servo[self.channel].angle = self.signal_inverter(angle)
        else:
            servodriver.servo[self.channel].angle = angle

        self.current_pos = end

# Servo-Objects:
RCD = Servo(channel=0,idle=0)   # Right Cabindoor
LCD = Servo(channel=1,idle=0)   # Left Cabindoor
RU = Servo(channel=2,idle=128)  # Rudder
LC = Servo(channel=3,idle=127)  # Left Canards #3
RC = Servo(channel=4,idle=128)  # Right Canards
LO = Servo(channel=5,idle=127)  # Left Aileron (Outboard, Querruder)
RO = Servo(channel=6,idle=127)  # Right Aileron
LF = Servo(channel=7,idle=127)  # Left Flaps
RF = Servo(channel=8,idle=127)  # Right Flaps
AB = Servo(channel=9,idle=0)    # Airbrakes
LG = Servo(channel=14,idle=0)   # in reality channel 15. Object used only for checking state