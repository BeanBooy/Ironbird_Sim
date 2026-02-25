import threading
from concurrent.futures import ThreadPoolExecutor
import time

# small buffer to handle high frequency input
class LastValueBuffer:

    __slots__ = ("lock", "value") # reserves memory for these attributes

    def __init__(self):
        self.lock = threading.Lock()
        self.value = None

    def set(self, v):
        with self.lock:
            self.value = v

    def get(self):
        with self.lock:
            return self.value

    def swap(self):
        with self.lock:
            v = self.value
            self.value = None # clear the current value
            return v

# Variables for LG
#I2CLG = 0x41
LG_IN = 0
LG_OUT = 1

# declared driver as None at beginning for errorhandling
#LGdriver = None
oldstate = LG_IN

executor = ThreadPoolExecutor(max_workers=1)
stop_event = threading.Event()

# Init bufferobject
lg_request_buffer = LastValueBuffer()

# NOTE Only for testing. would be in main
from adafruit_servokit import ServoKit
servodriver = ServoKit(channels=16, address=0x40, frequency=30)

# safe sleep to exit threads faster
def safe_sleep(seconds):
    for i in range(seconds*50):
        if stop_event.is_set():
            return
        time.sleep(0.02)

# Servosequence itself
def LGCD_Sequence(state, CDchannel, CDdriver=servodriver):
    global LGdriver
    if CDchannel is None:
        CDchannel = [0,1,2]

    if isinstance(CDchannel, int):
        CDchannel = [CDchannel]

    try:
        if state == LG_OUT:
            for angle in range(0,180):
                for channel in CDchannel:
                    CDdriver.servo[channel].angle = angle
            safe_sleep(1)
            servodriver.servo[15].fraction = LG_OUT
            safe_sleep(3)
        elif state == LG_IN:
            servodriver.servo[15].fraction = LG_IN
            safe_sleep(3)
            for angle in range(180,0,-1):
                for channel in CDchannel:
                    CDdriver.servo[channel].angle = angle
            safe_sleep(2)
        elif state is None:
            servodriver.servo[15].fraction = None
            safe_sleep(3)
            for channel in CDchannel:
                CDdriver.servo[channel].angle = None
    except Exception as e:
        print("Error with controlling LG:", e)

# Threadmanager
def lg_manager_thread(CDchannel=None, CDdriver=servodriver):

    global oldstate
    while not stop_event.is_set():
        # Wait for new arguments
        val = lg_request_buffer.get()
        if val is None:
            # if None, no argument got passed
            time.sleep(0.05) # we dont need safes_sleep here for such short pauses
            continue

        # Only take the last/current argument
        desired = lg_request_buffer.swap()
        if desired is None:
            continue

        # check for difference in new and past state
        if desired == oldstate:
            oldstate = desired
            continue

        # Wait for the executor to finish
        future = executor.submit(LGCD_Sequence, desired, CDchannel, CDdriver)
        try:
            # block new threads but wait for timeout
            while not future.done():
                if stop_event.wait(timeout=0.1):
                    break
            # after thread is finished: update oldstate
            oldstate = desired
        except Exception as e:
            print("Error in manager waiting for current thread to exit:", e)

# Set Buffer
def request_lg(state):
    lg_request_buffer.set(state)

# Threadhandling
def start_manager(CDchannel=None, CDdriver=servodriver):
    t = threading.Thread(target=lg_manager_thread, args=(CDchannel, CDdriver), daemon=True)
    t.start()
    return t

def shutdown():
    stop_event.set()
    executor.shutdown(wait=True)