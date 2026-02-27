#!/usr/bin/env python3
import sys
import signal
import socket
from gpiozero import LED, Device 
from gpiozero.pins.lgpio import LGPIOFactory
import threading 
import time
import RPi.GPIO as GPIO

Device.pin_factory = LGPIOFactory()

#GPIO-Pins der LEDs
LED_rot = LED(17)
#LED_grün = LED(27)
LED_w1 = LED(24)
#LED_w2 = LED(5)
LED_LG1 = LED(16)
#LED_LG2 = LED(26)

GPIO.setmode(GPIO.BCM)
GPIO.setup(LED_rot, GPIO.OUT)  # Setze Pin 17 als Ausgang für die rote LED
GPIO.setup(LED_w1, GPIO.OUT)   # Setze Pin 24 als Ausgang für die weiße LED 1
GPIO.setup(LED_LG1, GPIO.OUT)  # Setze Pin 16 als Ausgang für die Landing Gear LED 1

GPIO.output(LED_rot, GPIO.HIGH)  # Schalte die rote LED ein
GPIO.output(LED_w1, GPIO.HIGH)    # Schalte die weiße LED
GPIO.output(LED_LG1, GPIO.HIGH)  # Schalte die Landing Gear LED 1 ein



MODE = 0
PORT_CONST = 4443


try:
    # initialize socket
    HOST = '' # We are the Server
    PORT = PORT_CONST
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server_socket.bind((HOST, PORT))
    server_socket.listen(5)
    print(f"Server waits for {HOST}:{PORT}")
except Exception as e:
    print(f"Server could not be started: {e}")
    GPIO.cleanup()  # Bereinige die GPIO-Pins
    sys.exit(1)


#-------------------------------------------------------------------------------------------
# Main server loop

while True:
    try:
        print("Wait for Connection...")
        client_socket, addr = server_socket.accept()
        print(f"Connected to {addr} succesfull")
    #except Exception as e:
        #print(f"Connection cannot be established: {e}")
      #  break

    #try:
        while True:
            receivedData = client_socket.recv(16)
            if not receivedData:
                break
            if len(receivedData) < 10:
                print("Received data is too short to contain LED state information.")
                continue

            #Sicherheitscheck

            byte10 = receivedData[9]
            print(f"Empfangen:", list(receivedData))
            print(f"Byte 10:", byte10)

            chanlist = [17,24,16]

            GPIO.output(LED_rot, byte10 & 0b001)
            GPIO.output(LED_w1, byte10 & 0b010)
            GPIO.output(LED_LG1, byte10 & 0b100)
   
       
   # except Exception as e:
     #   print("Error with controlling LG:", e)

            
    except Exception as e:
        print(f"Connection error: {e}")
    finally:
        try:
            client_socket.close()
        except Exception:
            pass

