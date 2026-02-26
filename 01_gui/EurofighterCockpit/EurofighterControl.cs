using System;

namespace EurofighterCockpit
{
    internal static class EurofighterControl
    {
        // >> 1 same as /2 but more efficient on byte level
        private static byte rudderValue = byte.MaxValue >> 1;
        private static byte airbrakeValue = 0;

        private static byte airbrakeSpeed = 4;
        private static byte rudderSpeed = 3;

        public static byte AirbrakeValue { get => airbrakeValue; }

        public static byte FlapRight(ushort joystickX, ushort joystickY) {
            const double center = ushort.MaxValue / 2.0;
            // Normalize X:
            // Left  = -1
            // Right = +1
            double normX = (joystickX - center) / center;
            // Normalize Y (inverted):
            // Pull = +1
            // Push = -1
            double normY = (center - joystickY) / center;
            // Right flap mixing:
            // +Pull  increases
            // +Right increases
            double value = (normX + normY) / 2.0;
            value = Math.Max(-1.0, Math.Min(1.0, value));
            // Map [-1, +1] -> [0, 255]
            int result = (int)((value + 1.0) * 0.5 * 255.0);
            return (byte)result;
        }

        public static byte FlapLeft(ushort joystickX, ushort joystickY) {
            const double center = ushort.MaxValue / 2.0;
            // Normalize X:
            // Left  = -1
            // Right = +1
            double normX = (joystickX - center) / center;
            // Normalize Y (inverted):
            // Pull = +1
            // Push = -1
            double normY = (center - joystickY) / center;
            // Left flap mixing:
            // +Pull  increases
            // +Left  increases  (therefore subtract X)
            double value = (-normX + normY) / 2.0;
            value = Math.Max(-1.0, Math.Min(1.0, value));
            // Map [-1, +1] -> [0, 255]
            int result = (int)((value + 1.0) * 0.5 * 255.0);
            return (byte)result;
        }

        public static byte AileronRight(ushort joystickX, ushort joystickY) {
            // should have the same response
            return FlapRight(joystickX, joystickY);
        }

        public static byte AileronLeft(ushort joystickX, ushort joystickY) {
            // should have the same response
            return FlapLeft(joystickX, joystickY);
        }

        public static byte CanardRight(ushort joystickY) {
            return (byte)(byte.MaxValue - ScaleUShortToByte(joystickY));
        }

        public static byte CanardLeft(ushort joystickY) {
            return ScaleUShortToByte((ushort)(joystickY));
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
