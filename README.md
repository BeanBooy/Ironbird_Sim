Digital Servo Parameter (MD31092, MG DIGITAL SERVO von freewing):

Pulssewidhts:
min pulsewidth = 1400 µs (0°)
max pulsewidth = 2600 µs (90°)

frequency = 300 - 333Hz ONLY for DIGITAL SERVOS!!!


FOR TESTING YOURSELF:

for pulse in range(500, 3000, 50):  # 1000–2000 µs in 50 µs steps
    print("Pulse:", pulse)
    servo.set_pulse_width_range(pulse, pulse+1)
    servo.angle = 180 # angle desired to find pulsewidth needed
    time.sleep(1)

https://cdn-learn.adafruit.com/downloads/pdf/16-channel-pwm-servo-driver.pdf