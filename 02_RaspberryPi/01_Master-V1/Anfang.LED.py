# --- LED-Kanäle ---
# Kanal 0 = Landing Gear
STROBE_LEDS = [1, 2]       # Dauerblinker
SWITCH1_LEDS = [3, 4]      # Hebel 1 LEDs
SWITCH2_LEDS = [5, 6]      # Hebel 2 LEDs

# --- LED Threads ---
strobe_thread = None
strobe_event = None

led_thread = None
led_event = None

# Dauerblinker-Funktion
def strobe_sequence(stop_event):
    while not stop_event.is_set():
        for _ in range(2):  # Doppelblitz
            for ch in STROBE_LEDS:
                LGdriver.servo[ch].fraction = 1
            time.sleep(0.08)
            for ch in STROBE_LEDS:
                LGdriver.servo[ch].fraction = 0
            time.sleep(0.08)
        time.sleep(1.2)  # Pause zwischen Doppelblitzen

def start_strobe():
    global strobe_thread, strobe_event
    if strobe_thread is not None and strobe_thread.is_alive():
        return
    strobe_event = threading.Event()
    strobe_thread = threading.Thread(target=strobe_sequence, args=(strobe_event,))
    strobe_thread.start()

def stop_strobe():
    global strobe_event
    if strobe_event is not None:
        strobe_event.set()
    for ch in STROBE_LEDS:
        LGdriver.servo[ch].fraction = 0

# Hebel LEDs
def control_switch1(state):
    for ch in SWITCH1_LEDS:
        LGdriver.servo[ch].fraction = 1 if state == 1 else 0

def control_switch2(state):
    for ch in SWITCH2_LEDS:
        LGdriver.servo[ch].fraction = 1 if state == 1 else 0

# Landing Gear LEDs (optional, z.B. Lauflicht)
def LED_sequence(stop_event):
    while not stop_event.is_set():
        for channel in [1,2,3]:  # Beispiel-Lauflicht für Landing Gear LEDs
            if stop_event.is_set():
                return
            # alle aus
            for ch in [1,2,3]:
                LGdriver.servo[ch].fraction = 0
            # einen an
            LGdriver.servo[channel].fraction = 1
            time.sleep(0.15)

def start_LED_sequence():
    global led_thread, led_event
    if led_thread is not None and led_thread.is_alive():
        return
    led_event = threading.Event()
    led_thread = threading.Thread(target=LED_sequence, args=(led_event,))
    led_thread.start()

def stop_LED_sequence():
    global led_event
    if led_event is not None:
        led_event.set()
    for ch in [1,2,3]:
        LGdriver.servo[ch].fraction = 0

# --- Main Loop Integration ---
start_strobe()  # Strobe startet beim Programmstart

while True:
    receivedData = client_socket.recv(16)
    if not receivedData:
        break

    # Landing Gear Signal
    fractionLG = receivedData[LG]

    # Hebel LEDs
    switch1 = receivedData[10]
    switch2 = receivedData[11]
    control_switch1(switch1)
    control_switch2(switch2)

    # Landing Gear LEDs (Lauflicht), optional
    if fractionLG == 1:
        start_LED_sequence()
    else:
        stop_LED_sequence()
