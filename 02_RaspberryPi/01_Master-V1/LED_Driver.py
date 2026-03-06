from gpiozero import LED, Device
from gpiozero.pins.lgpio import LGPIOFactory

LED_rot = LED(17)    # red - Pos/Nav-Lights
LED_grün = LED(27)   # green
LED_LG1 = LED(16)    # landing gear 1 und 2
LED_LG2 = LED(26)

LED_POS =   0b0001
LED_LG =    0b0100
LED_ALL_ON = 0b0101
LED_ALL_OFF = 0b0000

# LED_LG function only for LGDB_Sequence
LED_LG_ON = 1
LED_LG_OFF = 0

def LED_LG_manager(toggleLED):
    if toggleLED == LED_LG_ON:
        LED_LG1.on()
        LED_LG2.on()
    elif toggleLED == LED_LG_OFF:
        LED_LG1.off()
        LED_LG2.off() 

def LED_manager(toggleLED):
    if toggleLED == LED_POS or toggleLED == 0b0011 or toggleLED == 0b0111:
        LED_rot.on()
        LED_grün.on()

    if toggleLED == LED_LG or toggleLED == 0b0110 or toggleLED == 0b0111:
        LED_LG1.on()
        LED_LG2.on()

    if toggleLED == LED_ALL_ON:
        LED_rot.on()
        LED_grün.on()
        LED_LG1.on()
        LED_LG2.on()

    elif toggleLED == LED_ALL_OFF:
        LED_rot.off()
        LED_grün.off()
        LED_LG1.off()
        LED_LG2.off()  
