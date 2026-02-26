using System;

namespace EurofighterCockpit
{
    internal static class EurofighterControl
    {
        private static byte airbrakeValue = 0;
        private static byte airbrakeSpeed = 3;
        private static byte rudderValue = byte.MaxValue >> 1;
        private static byte rudderSpeed = 3;

        public static byte AirbrakeValue { get => airbrakeValue; }

        public static byte FlapRight(ushort joystickY) {
            return ScaleUShortToByte(joystickY);
        }

        public static byte FlapLeft(ushort joystickY) {
            return (byte)(byte.MaxValue - ScaleUShortToByte(joystickY));
        }

        // ushort default pos = 32767
        // 32767 - 5000 = 27767
        // 32767 + 5000 = 37767
        public static byte AileronRight(ushort joystickX, ushort joystickY) {
            if (joystickX > 27767 && joystickX < 37767)
                return ScaleUShortToByte(joystickY);
            else
                return ScaleUShortToByte(joystickX);
        }

        public static byte AileronLeft(ushort joystickX, ushort joystickY) {
            if (joystickX > 27767 && joystickX < 37767)
                return (byte)(byte.MaxValue - ScaleUShortToByte(joystickY));
            else
                return ScaleUShortToByte(joystickX);
        }

        // >> 1 same as /2 bot more efficiant on byte level
        public static byte CanardRight(ushort joystickY, ushort joystickX) {
            ushort neutral = ushort.MaxValue >> 1;
            ushort adjustment = joystickX < neutral ? (ushort)((neutral - joystickX) >> 1) : (ushort)0;
            return ScaleUShortToByte((ushort)(joystickY + adjustment));
        }

        public static byte CanardLeft(ushort joystickY, ushort joystickX) {
            ushort neutral = ushort.MaxValue >> 1;
            ushort adjustment = joystickX > neutral ? (ushort)((joystickX - neutral) >> 1) : (ushort)0;
            return (byte)(byte.MaxValue - ScaleUShortToByte((ushort)(joystickY + adjustment)));
        }

        public static byte Rudder(bool rudderLeft, bool rudderRight, bool rudderReset) {
            if (rudderLeft)
                rudderValue = (byte)(rudderValue >= rudderSpeed ? rudderValue - rudderSpeed : 0);
            if (rudderRight)
                rudderValue = (byte)(rudderValue <= byte.MaxValue - rudderSpeed ? rudderValue + rudderSpeed : byte.MaxValue);
            if (rudderReset)
                rudderValue = Byte.MaxValue >> 1;
            return rudderValue;
        }

        public static byte Airbrake(bool airbrake) {
            // logic for airbrake linear curve,
            // cause using it as a bool would be way to snappy
            if (airbrake)
                airbrakeValue = (byte)(airbrakeValue <= byte.MaxValue - airbrakeSpeed ? airbrakeValue + airbrakeSpeed : byte.MaxValue);
            else
                airbrakeValue = (byte)(airbrakeValue >= airbrakeSpeed ? airbrakeValue - airbrakeSpeed : 0);
            return airbrakeValue;
        }

        public static byte Lights(bool positionLights, bool strobeLights, bool landingLight) {
            byte packed = (byte)(
                (positionLights ? 1 : 0) << 0 |
                (strobeLights ? 1 : 0) << 1 |
                (landingLight ? 1 : 0) << 2
            );
            return packed;
        }

        private static byte ScaleUShortToByte(ushort value) {
            // linear transformation: 65535 / 255 = 257 exactly
            byte scaled = (byte)(value / 257);
            return scaled;
        }

    }
}
