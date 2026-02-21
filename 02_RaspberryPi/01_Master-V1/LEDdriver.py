from gpiozero import LED
import threading
import time
# LED(GPIO-Port)
LED_NAV = LED(17) # bowfaced wingtip: rightside green, leftside red -> lit the hole time
LED_STROBE = LED(22) # white flashing lights (stern-faced)
LED_BEACON = LED(10) # read anticollision light beneight and above the hull -> blinks
LED_LG = LED(27) # is only lit with open/opening LG
LG_INMOTION = 1

def START_NAVLIGHTS(): # ik unneccessary but pls let me, it looks cleaner :)
    LED_NAV.on()

def START_STROBE_BEACONLIGHTS():
    LED_STROBE.on()
    LED_BEACON.on()
    time.sleep(0.05)
    LED_STROBE.off()
    time.sleep(0.05)
    LED_STROBE.on()
    time.sleep(0.05)
    LED_STROBE.off()
    LED_BEACON.off()
    time.sleep(0.85)


def LG_LIGHT():
    global flag_LG # works with same flag as in main

    while flag_LG != LG_INMOTION:
        LED_LG.on()
    LED_LG.off()


def OTHER_LIGHTS(state = False):
    while state == True:
        START_NAVLIGHTS()
        START_STROBE_BEACONLIGHTS()
        # NOTE: implement OTHER_LIGHTS in main using multithreading