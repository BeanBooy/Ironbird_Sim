from gpiozero import LED, Device 
from gpiozero.pins.lgpio import LGPIOFactory
import threading 
import time

Device.pin_factory = LGPIOFactory()


#Eingänge der LEDs
LED_rot = LED(17)
LED_grün = LED(27)
LED_w1 = LED(24)
LED_w2 = LED(5)
#LED_LG1 = LED()
LED_LG2 = LED(26)


#LEDs anschalten
LED_rot.on()
LED_grün.on()
LED_w1.on()
LED_w2.on()
#LED_LG1.on()
LED_LG2.on()

time.sleep(8)          #kurze Pause

#try:
    #while True:
     

except KeyboardInterrupt:
    LED_rot.off()                #LEDs werden ausgeschalten
    LED_grün.off()
    LED_w1.off()
    LED_w2.off()
    #LED_LG1.off()
    LED_LG2.off()

    LED_rot.close()              #Freigeben der LEDs
    LED_grün.close()
    LED_w1.close()
    LED_w2.close()
    #LED_LG1.close()
    LED_LG2.close()
    print("Die LED wurde ausgeschalten und der GPIO_PIN wieder freigegeben")
