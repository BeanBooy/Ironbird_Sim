from adafruit_servokit import ServoKit

servodriver = ServoKit(channels=16,address=0x40,frequency=30)


class Servo:
    def __init__(self, channel, idle, actuation_range = 256, min_pulsewidth = 1000, max_pulsewidth = 2000, inverted = False):
        self.channel = channel
        self.idle = idle
        self.inverted = inverted
        self.min_pos = 0
        self.max_pos = actuation_range
        self.mid_pos = int(self.max_pos/2)
        self.current_pos = idle
        self.pulsewidth = servodriver.servo[self.channel].set_pulse_width_range(min_pulsewidth, max_pulsewidth)
        servodriver.servo[self.channel].actuation_range = actuation_range

    def signal_inverter(self,receivedDATA):
        angle = (256 - receivedDATA)
        return angle
    
    def move(self, angle):
        if angle == None: # detach servo, nothing more
            servodriver.servo[self.channel].angle = None
            return
        #angle = int(angle*0.703125) # NOTE: from 0 to 256 -> 0° to 180°
        start = self.current_pos
        end = angle
        step = 1
        steps = end-start

        #delay = int(seconds / steps) # NOTE if you want to declare the movementspeed

        if start > end:
            step = -1
        if steps == 0:
            return

        if self.inverted == True:
            servodriver.servo[self.channel].angle = self.signal_inverter(angle)
                #time.sleep(delay)
        else:
            servodriver.servo[self.channel].angle = angle
                #time.sleep(delay)

        self.current_pos = end

#LC = 3  # Left Canards
#RC = 4  # Right Canards
#LO = 5  # Left Aileron (Outboard, Querruder)
#RO = 6  # Right Aileron
#LF = 7	# Left Flaps
#RF = 8 # Right Flaps
#AB = 9 # Airbrakes
#LG = 15 # Landing Gear