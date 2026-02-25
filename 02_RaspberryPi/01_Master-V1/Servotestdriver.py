import time
from adafruit_servokit import ServoKit
from concurrent.futures import ThreadPoolExecutor
import threading


I2CSERVO = 0x40

servodriver = ServoKit(channels=16, address=I2CSERVO, frequency=30)
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
LG = 15 # Landing Gear

def safe_sleep(seconds):
    for i in range(seconds * 20):  # 20 checks per second
        if stop_test.is_set():
            return
        time.sleep(0.05)

# only for testenvironment, is done in main by default
def initPW():
    for channel in range(15):
        servodriver.servo[channel].set_pulse_width_range(1000,2000)

# for fancier testing or inverted servos
def signal_inverter(receivedDATA):
    angle = (180 - receivedDATA)
    return angle

def move_LG(fraction):
    servodriver.servo[LG].fraction = fraction
    safe_sleep(2)

def show_move():
    # movement out
    for angle in range(180, 0, -1):
        if stop_test.is_set():
            break
        servodriver.servo[LC].angle = angle
        servodriver.servo[RC].angle = signal_inverter(angle)
        servodriver.servo[LO].angle = angle
        servodriver.servo[RO].angle = signal_inverter(angle)
        servodriver.servo[LF].angle = angle
        servodriver.servo[RF].angle = signal_inverter(angle)
        servodriver.servo[AB].angle = angle
        time.sleep(0.0014)
    move_LG(0)
    for angle in range(180, 0, -1):
        servodriver.servo[0].angle = angle
        servodriver.servo[1].angle = angle
        servodriver.servo[2].angle = angle
        time.sleep(0.001)
    safe_sleep(2)
    for angle in range(0, 180):
        if stop_test.is_set():
            break
        servodriver.servo[LC].angle = angle
        servodriver.servo[RC].angle = signal_inverter(angle)
        servodriver.servo[LO].angle = angle
        servodriver.servo[RO].angle = signal_inverter(angle)
        servodriver.servo[LF].angle = angle
        servodriver.servo[RF].angle = signal_inverter(angle)
        servodriver.servo[AB].angle = angle
        time.sleep(0.0014)

    for angle in range(0, 180):
        servodriver.servo[0].angle = angle
        servodriver.servo[1].angle = angle
        servodriver.servo[2].angle = angle
    safe_sleep(2)
    move_LG(1)
    # movement in

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
        # only run one thread at a time
        stop_test.set()
        if current_test_future and not current_test_future.done():
            current_test_future.cancel()

        # new thread can be started
        stop_test.clear()

        # start new thread
        current_test_future = executor.submit(ServoTest)


def stop_servo_test():
    global current_test_future

    with future_lock:
        stop_test.set()
        if current_test_future:
            current_test_future.cancel()


