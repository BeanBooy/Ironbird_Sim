import threading
from concurrent.futures import ThreadPoolExecutor
import time

# -------------------------
# Last-value buffer
# -------------------------
class LastValueBuffer:
    """Thread-safe buffer that always keeps the latest value (with timestamp)."""
    __slots__ = ("_lock", "_value", "_ts")

    def __init__(self):
        self._lock = threading.Lock()
        self._value = None
        self._ts = 0.0

    def set(self, v):
        with self._lock:
            self._value = v
            self._ts = time.time()

    def get(self):
        with self._lock:
            return self._value, self._ts

    def swap(self):
        """Atomically take the current value and clear it."""
        with self._lock:
            v, t = self._value, self._ts
            self._value = None
            self._ts = 0.0
            return v, t

# -------------------------
# Deine vorhandenen Variablen (angepasst)
# -------------------------
I2CLG = 0x41
LG_IN = 0
LG_OUT = 1

LGdriver = None
oldstate = LG_IN

executor = ThreadPoolExecutor(max_workers=1)
stop_event = threading.Event()

# Buffer für eingehende Requests (nur letzter Wert zählt)
lg_request_buffer = LastValueBuffer()

# Beispiel: servodriver initialisiert du wie gehabt
from adafruit_servokit import ServoKit
servodriver = ServoKit(channels=16, address=0x40, frequency=333)

# -------------------------
# safe_sleep wie gehabt
# -------------------------
def safe_sleep(seconds):
    for i in range(seconds*50):
        if stop_event.is_set():
            return
        time.sleep(0.02)

    #stop_event.wait(timeout=seconds)

# -------------------------
# LG Sequencer (unverändert, nur Name angepasst)
# -------------------------
def LGCD_Sequence(state, CDchannel, CDdriver=servodriver):
    global LGdriver
    if CDchannel is None:
        CDchannel = [0,1,2]

    if LGdriver is None:
        try:
            LGdriver = ServoKit(channels=16, address=I2CLG, frequency=30)
        except Exception as e:
            print(f"(LG) ServoKit could not be initialized: {e}")
            return

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
        elif state is None:
            LGdriver.servo[0].fraction = None
            safe_sleep(6)
            for channel in CDchannel:
                CDdriver.servo[channel].angle = None
    except Exception as e:
        print("Error with controlling LG:", e)

# -------------------------
# Manager-Thread: liest Buffer und startet Sequenzen nur für den letzten Wert
# -------------------------
def lg_manager_thread(CDchannel=None, CDdriver=servodriver):
    """
    Läuft im Hintergrund:
    - wartet auf einen neuen Wunsch im Buffer
    - startet die Sequenz (über executor) und wartet auf deren Ende
    - nach Ende liest er erneut den Buffer (swap) und startet ggf. die nächste Sequenz
    """
    global oldstate
    while not stop_event.is_set():
        # Warte aktiv auf eine neue Anforderung (polling mit kurzem Sleep)
        val, ts = lg_request_buffer.get()
        if val is None:
            # kein Request vorhanden -> kurz schlafen
            time.sleep(0.05)
            continue

        # Nimm die aktuellste Anforderung atomar (clear)
        desired, _ = lg_request_buffer.swap()
        if desired is None:
            continue

        # Wenn Wunsch gleich aktuellem Zustand, überspringen
        if desired == oldstate:
            # setze oldstate trotzdem, falls None etc.
            oldstate = desired
            continue

        # Wenn Executor bereits eine Aufgabe hat, warten bis sie fertig (max_workers=1 sorgt dafür)
        # Wir submitten die Sequenz und warten auf deren Ende, danach prüfen wir erneut den Buffer.
        future = executor.submit(LGCD_Sequence, desired, CDchannel, CDdriver)
        try:
            # blockierend warten, aber mit Timeout, damit stop_event geprüft werden kann
            while not future.done():
                if stop_event.wait(timeout=0.1):
                    break
            # nach Ende: update oldstate
            oldstate = desired
        except Exception as e:
            print("Error in manager waiting for future:", e)

# -------------------------
# API: statt direkt submitten -> setze Buffer
# -------------------------
def request_lg(state):
    """
    Aufrufe aus TCP/GUI/Joystick sollten request_lg(state) verwenden.
    Das schreibt nur den letzten Wunsch in den Buffer.
    """
    lg_request_buffer.set(state)

# -------------------------
# Start/Stop Hilfsfunktionen
# -------------------------
def start_manager(CDchannel=None, CDdriver=servodriver):
    t = threading.Thread(target=lg_manager_thread, args=(CDchannel, CDdriver), daemon=True)
    t.start()
    return t

def shutdown():
    stop_event.set()
    executor.shutdown(wait=True)

# -------------------------
# Beispiel: initialisieren
# -------------------------
if __name__ == "__main__":
    # Manager starten (z.B. mit default CDchannel)
    manager_thread = start_manager(CDchannel=[0,1,2], CDdriver=servodriver)

    # Beispiel: mehrere schnelle Requests
    request_lg(LG_OUT)
    time.sleep(0.1)
    request_lg(LG_IN)
    time.sleep(0.1)
    request_lg(LG_OUT)
    # nur der letzte Wert bleibt im Buffer; der Manager startet nacheinander Sequenzen,
    # aber immer nur für den jeweils aktuellsten Wunsch nach Abschluss der laufenden Sequenz.

    try:
        while True:
            time.sleep(0.5)
    except KeyboardInterrupt:
        shutdown()
