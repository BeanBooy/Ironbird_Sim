import time
from adafruit_servokit import ServoKit
from concurrent.futures import ThreadPoolExecutor
import threading


I2CSERVO = 0x40

LGdriver = ServoKit(channels=16,address=0x41,frequency=30)
servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=333)
executor = ThreadPoolExecutor(max_workers=4)
lock = threading.Lock()
# represent each channel not like in main
LC = 3  # Left Canards
RC = 4  # Right Canards
LO = 5  # Left Aileron (Outboard, Querruder)
RO = 6  # Right Aileron
LF = 7	# Flaps Inboard
RF = 8 # Flaps Outboard
AB = 9 # Airbrakes
LG = 0 # Landing Gear

def initPW():
    for channel in range(16):
        servodriver.servo[channel].set_pulse_width_range(1000,2000)
def signal_inverter(receivedDATA):
    angle = (180 - receivedDATA)
    return angle

def show_move_LG(fraction):
    LGdriver.servo[0].fraction = fraction
    time.sleep(5)

def show_move(channel1, channel2):
    # movement 1
    with lock:
        servodriver.servo[channel1].angle = 180
        servodriver.servo[channel2].angle = signal_inverter(180)
    time.sleep(1)

    # movement 2
    with lock:
        servodriver.servo[channel1].angle = 0
        servodriver.servo[channel2].angle = signal_inverter(0)
    time.sleep(1)
#channel 0-2 reserved for CD
def ServoTest():
    initPW()
    executor = ThreadPoolExecutor(max_workers=2)
    executor.submit(show_move_LG,1)
    # Für jedes Paar einen Thread starten
    for channel in range(0, 15, 2):
        executor.submit(show_move, channel, channel + 1)
    print(f"{threading.active_count()} threads active")
    executor.submit(show_move_LG,0)
    executor.shutdown(wait=True)
    print("Alle Servos wurden gleichzeitig getestet.")

ServoTest()
