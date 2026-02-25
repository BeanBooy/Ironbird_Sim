import time
from adafruit_servokit import ServoKit
from concurrent.futures import ThreadPoolExecutor
import threading


I2CSERVO = 0x40
CHANNEL_LG = 15

#LGdriver = ServoKit(channels=16,address=0x41,frequency=30)
servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=30)
#executor = ThreadPoolExecutor(max_workers=4)
#lock = threading.Lock()
stop_test = threading.Event()
executor = ThreadPoolExecutor(max_workers=1)

# represent each channel not like in main
LC = 3  # Left Canards
RC = 4  # Right Canards
LO = 5  # Left Aileron (Outboard, Querruder)
RO = 6  # Right Aileron
LF = 7	# Flaps Inboard
RF = 8 # Flaps Outboard
AB = 9 # Airbrakes
LG = 0 # Landing Gear

def safe_sleep(seconds):
    for i in range(seconds * 20):  # 20 checks pro Sekunde
        if stop_test.is_set():
            return
        time.sleep(0.05)


def initPW():
    for channel in range(15):
        servodriver.servo[channel].set_pulse_width_range(1000,2000)

def signal_inverter(receivedDATA):
    angle = (180 - receivedDATA)
    return angle

def move_LG(fraction):
    servodriver.servo[CHANNEL_LG].fraction = fraction
    safe_sleep(2)

def show_move():
    # movement 1
    # with lock:

    for channel in range(3, 14, 2):
        if stop_test.is_set():
            break
        servodriver.servo[channel].angle = 180
        servodriver.servo[channel+1].angle = signal_inverter(180)
    for channel in range(3):
        servodriver.servo[channel].angle = 180
    safe_sleep(2)
    move_LG(1)
    # movement 2
    # with lock:
    for channel in range(3, 14, 2):
        if stop_test.is_set():
            break
        servodriver.servo[channel].angle = 0
        servodriver.servo[channel+1].angle = signal_inverter(0)
    move_LG(0)
    for channel in range(3):
        servodriver.servo[channel].angle = 0
    safe_sleep(2)
    # movement 3 "Idle"

def idle():
    move_LG(0)
    for channel in range(16):
        if stop_test.is_set():
            break
        if channel == 0 or channel == 1 or channel == 2 or channel == 7:
            servodriver.servo[channel].angle = 0
        else:
            servodriver.servo[channel].angle = 90
    safe_sleep(1)

current_test_future = None
future_lock = threading.Lock()

# channel 0-2 reserved for CD
# channel 15 reserved for LG
def ServoTest():
    while not stop_test.is_set():
        # initPW() # NOTE uncomment for testing out of main
        show_move()
        print(f"{threading.active_count()} threads active")
        print("Alle Servos wurden gleichzeitig getestet.")

# Threadhandling
def start_servo_test():
    global current_test_future

    with future_lock:
        # Falls ein Test läuft → abbrechen
        stop_test.set()
        if current_test_future and not current_test_future.done():
            current_test_future.cancel()

        # Neues Event für neuen Test
        stop_test.clear()

        # Neuen Test starten
        current_test_future = executor.submit(ServoTest)


def stop_servo_test():
    global current_test_future

    with future_lock:
        stop_test.set()
        if current_test_future:
            current_test_future.cancel()
initPW()
#start_servo_test()
#stop_servo_test()

