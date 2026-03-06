import time
from adafruit_servokit import ServoKit
from ServoObjects import RCD, LCD, RU, LC, RC, LO, RO, LF, RF, AB, LG
from concurrent.futures import ThreadPoolExecutor
import threading
import LED_Driver
from LED_Driver import LED_ALL_OFF, LED_ALL_ON

LG_OUT = 1
LG_IN = 0

NUMCYCLES = 2
I2CSERVO = 0x40
servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=50)

stop_test = threading.Event()
executor = ThreadPoolExecutor(max_workers=1)
current_test_future = None
future_lock = threading.Lock()

def safe_sleep(seconds):
    for i in range(seconds*50):
        if stop_test.is_set():
            return 
        time.sleep(0.02)

def test_move():
    try:
        for cycles in range(NUMCYCLES):
            LED_Driver.LED_manager(LED_ALL_ON)
            if not stop_test.is_set():
                for byte_value in range(0,256):
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

                for byte_value in range(256,-1,-1):
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
                # close LG
                servodriver.servo[15].fraction = LG_IN
                LG.current_pos = LG_IN
                safe_sleep(3)
                if LG.current_pos == LG_IN and not stop_test.is_set():
                    RCD.move(RCD.idle)
                    LCD.move(LCD.idle)
                LED_Driver.LED_manager(LED_ALL_OFF)
    finally:
        # set rest to idle again
        RU.move(RU.idle)
        LC.move(LC.idle)
        RC.move(RC.idle)
        LO.move(LO.idle)
        RO.move(RO.idle)
        LF.move(LF.idle)
        RF.move(RF.idle)
        AB.move(AB.idle)
        print(f"End of Servotest, went through {NUMCYCLES} cycle(s)")

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
        LED_Driver.LED_manager(LED_ALL_OFF)
        if LG.current_pos == LG_IN and RCD.current_pos == RCD.max_pos:
            print("Closing Cabindoors...")
            time.sleep(2) # blocks input-data but is acceptable because test is not used practical
            RCD.move(RCD.idle)
            LCD.move(LCD.idle)
        if current_test_future:
            current_test_future.cancel()

#test_move(MODE) # if you want to test uncommend