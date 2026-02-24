from adafruit_servokit import ServoKit
import threading
from concurrent.futures import ThreadPoolExecutor # multithreadingmanager
import queue


I2CLG = 0x41
LG_IN = 0
LG_OUT = 1
global LG_INMOTION
LG_INMOTION = None
LGdriver = None
oldstate = LG_IN

_STOP = None

executor = ThreadPoolExecutor(max_workers=1)
q = queue.Queue(maxsize=1)

# Threading
stop_event = threading.Event()

servodriver = ServoKit(channels=16, address=0x40, frequency=333) # only for testing here, would be in main

def safe_sleep(seconds):
     stop_event.wait(timeout=seconds)

# Must be imported for main
def initLG():
    global LGdriver
    try:
        # Initialize communication to LG-PCA-board
        LGdriver = ServoKit(channels=16,address=I2CLG,frequency=30)

    except Exception as e:
        print(f"(LG) ServoKit could not be initialized: {e}")

def LGCD_Sequencer(state,CDchannel,CDdriver=servodriver):
    if CDchannel == None:
        CDchannel = [0,1,2]

    if LGdriver == None:
        initLG()

    if isinstance(CDchannel, int):
        CDchannel = [CDchannel]
    try:
        if state == LG_OUT:
            for channel in CDchannel:
                    CDdriver.servo[channel].angle = 180
            safe_sleep(3)
            LGdriver.servo[0].fraction = LG_OUT
            safe_sleep(6)
        elif state == LG_IN:
            LGdriver.servo[0].fraction = LG_IN
            safe_sleep(6)
            for channel in CDchannel:
                CDdriver.servo[channel].angle = 90
            safe_sleep(3)
        elif state == None:
            LGdriver.servo[0].fraction = None
            safe_sleep(6)
            for channel in CDchannel:
                CDdriver.servo[channel].angle = None
    except:
        print("Error with controlling LG")
    
def start_LGCD_thread(CDchannel=None,state=LG_IN,CDdriver=servodriver):
    global oldstate
    global LG_INMOTION
    if LG_INMOTION is None or LG_INMOTION.done():
        # only one task is running
        LG_INMOTION = executor.submit(LGCD_Sequence,state,CDchannel,CDdriver) # 1 0 0 0 1 1 0 1 0
        oldstate = state
    else:
        if LG_INMOTION and oldstate == state:
            oldstate = state
            LG_INMOTION = executor.submit(LGCD_Sequence,state,CDchannel,CDdriver)
        #print(f"LG in motion, skiped request {state} request")

def shutdown():
    print(f"Ending {threading.active_count()-2} remaining Threads", end="\r") # -2 threads because these are the default programms
    stop_event.is_set()
    executor.shutdown(wait=True)
    print(f"Exited all Threads".ljust(50))

#NOTE --> ThreadPoolExecutor.shutdown() im handle_exit