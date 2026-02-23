#from gpiozero import LED
#from time import sleep

from gpiozero import LED, Device 
from gpiozero.pins.lgpio import LGPIOFactory
import threading 
import time

Device.pin_factory = LGPIOFactory()

#Eingänge der LEDs


LED_LG = LED(17)
LED_LG.on()
time.sleep(5)
#try:
    #while True:
        #led.toggle()
        #sleep(0.5)
        
#except KeyboardInterrupt:
    #LED_LG.off()
    #LED_LG.close()
    #print("Die LED wurde ausgeschalten und der GPIO_PIN wieder freigegeben")
 

