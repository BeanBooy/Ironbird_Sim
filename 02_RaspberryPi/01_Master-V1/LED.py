from gpiozero import LED
from time import sleep

#Eingänge der LEDs

def main() -> None:
LED_LG = LED(17)
LED_LG.off()

try:
    while True:
        led.toggle()
        sleep(0.5)
        
except KeyboardInterrupt:
    LED_LG.off()
    LED_LG.close()
    print("Die LED wurde ausgeschalten und der GPIO_PIN wieder freigegeben")
 

