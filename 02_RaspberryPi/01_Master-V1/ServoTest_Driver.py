import time
from adafruit_servokit import ServoKit
from concurrent.futures import ThreadPoolExecutor
import threading
from ServoClass import Servo

LG_OUT = 1
LG_IN = 0

I2CSERVO = 0x40
servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=30)

stop_test = threading.Event()
executor = ThreadPoolExecutor(max_workers=1)
current_test_future = None
future_lock = threading.Lock()

RCD = Servo(channel=0,idle=0)
LCD = Servo(channel=1,idle=0)
RU = Servo(channel=2,idle=90)
LC = Servo(channel=3,idle=128)
RC = Servo(channel=4,idle=128,inverted=False) # inverted for show
LO = Servo(channel=5,idle=128)
RO = Servo(channel=6,idle=128,inverted=False)
LF = Servo(channel=7,idle=128)
RF = Servo(channel=8,idle=128,inverted=False)
AB = Servo(channel=9,idle=0)
LG = Servo(channel=14,idle=0) # in reality channel 15. Object used only for checking state

def safe_sleep(seconds):
    for i in range(seconds*50):
        if stop_test.is_set():
            return 
        time.sleep(0.02)

def test_move():
    for cycles in range(2):
        if not stop_test.is_set():
            for byte_value in range(0,256+1):
                if stop_test.is_set():
                    break
                RU.move(byte_value)
                LC.move(byte_value)
                RC.move(byte_value)
                LO.move(byte_value)
                RO.move(byte_value)
                LF.move(byte_value)
                RF.move(byte_value)
                AB.move(byte_value)
                time.sleep(0.002) # for smoother movement

            RCD.move(RCD.max_pos)
            LCD.move(LCD.max_pos)
            safe_sleep(1)
            if RCD.current_pos == RCD.max_pos and LCD.current_pos == LCD.max_pos and not stop_test.is_set():
                servodriver.servo[15].fraction = LG_OUT
                LG.current_pos = LG_OUT

            for byte_value in range(256,0,-1):
                if stop_test.is_set():
                    break
                RU.move(byte_value)
                LC.move(byte_value)
                RC.move(byte_value)
                LO.move(byte_value)
                RO.move(byte_value)
                LF.move(byte_value)
                RF.move(byte_value)
                AB.move(byte_value)
                time.sleep(0.005) # for smoother movement
            #if RCD.current_pos is not RCD.idle and LCD.current_pos is not LCD.idle and MODE == 2:
            servodriver.servo[15].fraction = LG_IN
            LG.current_pos = LG_IN
            safe_sleep(3)
            if LG.current_pos == LG_IN and not stop_test.is_set():
                RCD.move(RCD.idle)
                LCD.move(LCD.idle)
    print(f"End of Servotest, went through {cycles+1} cycle")

def start_servo_test():
    global current_test_future
    with future_lock:
        stop_test.set()
        if current_test_future and not current_test_future.done():
            current_test_future.cancel()

        # new thread can be started
        stop_test.clear()

        # start new thread
        current_test_future = executor.submit(test_move)

def stop_servo_test():
    global current_test_future

    with future_lock:
        stop_test.set()
        if LG.current_pos == LG_IN and RCD.current_pos == RCD.max_pos:
            time.sleep(2)
            RCD.move(RCD.idle)
            LCD.move(LCD.idle)
        if current_test_future:
            current_test_future.cancel()

#test_move(MODE)