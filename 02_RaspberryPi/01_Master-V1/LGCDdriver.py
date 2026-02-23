import threading
from adafruit_servokit import ServoKit
import time

I2CSERVO = 0x40
I2CLG = 0x41

LG_OUT = 1
LG_IN = 0

delay = 6

stop_thread = threading.Event()
lock = threading.Lock()
lgcd_thread = None
lgcd_event = None
lgcd_state = LG_IN
lgcd_channels = [0,1,2]

LGdriver = ServoKit(channels=16,address=I2CLG,frequency=30)
servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=333)

def start_LGCD_thread(channels, state=LG_IN):
    global lgcd_thread, lgcd_event, lgcd_state

    # if input equals thread, return current thread
    if lgcd_thread is not None and lgcd_thread.is_alive():
        lgcd_event.state = state
        return lgcd_thread

    # new input and no current thread, start new thread
    lgcd_event = threading.Event()
    lgcd_event.state = state

    lgcd_thread = threading.Thread(target=LGCD_sequence, args=(lgcd_event, channels))
    lgcd_thread.start()

    return lgcd_thread


def safe_sleep(seconds):                # short sleeptime to assure correct exit of thread
     for i in range(int(seconds * 10)): 
        if stop_thread.is_set(): 
            return 
        time.sleep(0.1)

class LGCD():
    def __init__(self, name):
        self.name = name

    def move_LG(self, state):
        if state == LG_OUT:
            LGdriver.servo[0].fraction = LG_OUT # frction can be min 0 or max 1
            safe_sleep(delay)
        elif state == LG_IN:
            LGdriver.servo[0].fraction = LG_IN
            safe_sleep(delay)
        elif state == None:
            LGdriver.servo[0].fraction = None
        
    def move(self,servo,angle,pause=True):
        if isinstance(servo, int): # if only one channel given: channel -> list of channel(s)
            servo = [servo]
        for channel in servo:
            servodriver.servo[channel].angle = angle
        if pause == True:
          safe_sleep(delay/2)

LaG = LGCD("LandingGear")       # Initialize Classobjects
CaD = LGCD("CabinDoor")

def LGCD_sequence(channels):
    global lgcd_event

    if stop_thread.is_set():
        return
    
    with lock:

        if isinstance(channels, int):
            channels = [channels]
            
        if lgcd_event == LG_OUT:
            for channel in channels:
                if stop_thread.is_set(): return
                CaD.move(channel,180,False)

            safe_sleep(delay/2)
            if stop_thread.is_set(): return

            LaG.move_LG(LG_OUT)

        elif lgcd_event == LG_IN:
            if stop_thread.is_set(): return
            LaG.move_LG(LG_IN)

            for channel in channels:
                if stop_thread.is_set(): return
                CaD.move(channel,90,False)


