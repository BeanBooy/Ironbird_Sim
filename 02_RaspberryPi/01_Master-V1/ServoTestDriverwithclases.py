import time
from adafruit_servokit import ServoKit
from concurrent.futures import ThreadPoolExecutor
import threading
from Sequencer import Servo

LG_OUT = 1
LG_IN = 0

I2CSERVO = 0x40
servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=30)

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

MODE = 2

def safe_sleep(seconds):
    for i in range(seconds*50):
        if MODE != 2:
            break
        time.sleep(0.02)

def test_move(MODE):
    for byte_value in range(0,256+1):
        if MODE != 2:
            return
        RU.move(byte_value)
        LC.move(byte_value)
        RC.move(byte_value)
        LO.move(byte_value)
        RO.move(byte_value)
        LF.move(byte_value)
        RF.move(byte_value)
        AB.move(byte_value)
        if MODE != 2:
            return
        time.sleep(0.002) # for smoother movement

    RCD.move(RCD.max_pos)
    LCD.move(LCD.max_pos)
    safe_sleep(1)
    if RCD.current_pos == RCD.max_pos and LCD.current_pos == LCD.max_pos and MODE == 2:
        servodriver.servo[15].fraction = LG_OUT
        LG.current_pos = LG_OUT
    elif MODE != 2:
        return

    for byte_value in range(256,0,-1):
        if MODE != 2:
            return
        RU.move(byte_value)
        LC.move(byte_value)
        RC.move(byte_value)
        LO.move(byte_value)
        RO.move(byte_value)
        LF.move(byte_value)
        RF.move(byte_value)
        AB.move(byte_value)
        if MODE != 2:
            return
        time.sleep(0.005) # for smoother movement
    #if RCD.current_pos is not RCD.idle and LCD.current_pos is not LCD.idle and MODE == 2:
    servodriver.servo[15].fraction = LG_IN
    LG.current_pos = LG_IN
    safe_sleep(3)
    if MODE != 2:
            return
    if LG.current_pos == LG_IN and MODE == 2:
        RCD.move(RCD.idle)
        LCD.move(LCD.idle)
    
#test_move(MODE)
