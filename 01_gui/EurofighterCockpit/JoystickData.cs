using System;

namespace EurofighterCockpit
{
    internal class JoystickData
    {
        private bool throttleConnected;
        private bool joystickConnected;

        // joystick
        private ushort joystickX = ushort.MaxValue / 2;
        private ushort joystickY = ushort.MaxValue / 2;
        private ushort joystickTorque;  // ???
        private bool airbrake;
        private bool trigger;

        // throttle
        private ushort throttle = ushort.MaxValue;  // actually not needed for the model
        private bool rudderLeft;
        private bool rudderRight;
        private bool rudderReset;
        private bool sound;
        private bool landingGear;
        private bool positionalLights;
        private bool strobeLights;
        private bool landingLights;

        public bool ThrottleConnected { get => throttleConnected; set => throttleConnected = value; }
        public bool JoystickConnected { get => joystickConnected; set => joystickConnected = value; }
        public ushort JoystickX { get => joystickX; set => joystickX = value; }
        public ushort JoystickY { get => joystickY; set => joystickY = value; }
        public ushort JoystickTorque { get => joystickTorque; set => joystickTorque = value; }
        public bool Airbrake { get => airbrake; set => airbrake = value; }
        public bool Trigger { get => trigger; set => trigger = value; }
        public ushort Throttle { get => throttle; set => throttle = value; }
        public bool RudderLeft { get => rudderLeft; set => rudderLeft = value; }
        public bool RudderRight { get => rudderRight; set => rudderRight = value; }
        public bool RudderReset { get => rudderReset; set => rudderReset = value; }
        public bool Sound { get => sound; set => sound = value; }
        public bool LandingGear { get => landingGear; set => landingGear = value; }
        public bool PositionalLights { get => positionalLights; set => positionalLights = value; }
        public bool StrobeLights { get => strobeLights; set => strobeLights = value; }
        public bool LandingLights { get => landingLights; set => landingLights = value; }
        public double JoystickXPercent { get => (Convert.ToDouble(joystickX) - ushort.MaxValue / 2) / ushort.MaxValue * 2; }
        public double JoystickYPercent { get => (Convert.ToDouble(joystickY) - ushort.MaxValue / 2) / ushort.MaxValue * -2; }
        public double JoystickTorquePercent { get => (joystickTorque - ushort.MaxValue / 2) / ushort.MaxValue; }
        public double ThrottlePercent { get => (Convert.ToDouble(throttle) - ushort.MaxValue) / -ushort.MaxValue; }

        public override bool Equals(object obj) {
            if (obj is JoystickData other) {
                return throttleConnected == other.throttleConnected &&
                    joystickConnected == other.joystickConnected &&
                    joystickX == other.joystickX &&
                    joystickY == other.joystickY &&
                    joystickTorque == other.joystickTorque &&
                    airbrake == other.airbrake &&
                    trigger == other.trigger &&
                    throttle == other.throttle &&
                    rudderLeft == other.rudderLeft &&
                    rudderRight == other.rudderRight &&
                    rudderReset == other.rudderReset &&
                    sound == other.sound &&
                    landingGear == other.landingGear &&
                    positionalLights == other.positionalLights &&
                    strobeLights == other.strobeLights &&
                    landingLights == other.landingLights;
            }
            else
                return false;
        }

        public override int GetHashCode() {
            // needs to be overwritten to prevent warning
            return 0;
        }

    }
}
