using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurofighterCockpit
{
    internal static class EurofighterControl
    {
        private static byte airbrakeValue = 0;

        public static byte AirbrakeValue { get => airbrakeValue; }

        public static byte flapRight(ushort joystickY) {
            return scaleUShortToByte(joystickY);
        }

        public static byte flapLeft(ushort joystickY) {
            return (byte)(byte.MaxValue - scaleUShortToByte(joystickY));
        }

        // ushort default pos = 32767
        // 32767 - 5000 = 27767
        // 32767 + 5000 = 37767
        public static byte aileronRight(ushort joystickX, ushort joystickY) {
            if (joystickX > 27767 && joystickX < 37767)
                return scaleUShortToByte(joystickY);
            else
                return scaleUShortToByte(joystickX);
        }

        public static byte aileronLeft(ushort joystickX, ushort joystickY) {
            if (joystickX > 27767 && joystickX < 37767)
                return (byte)(byte.MaxValue - scaleUShortToByte(joystickY));
            else
                return scaleUShortToByte(joystickX);
        }

        // >> 1 same as /2 bot more efficiant on byte level
        public static byte canardRight(ushort joystickY, ushort joystickX) {
            ushort neutral = ushort.MaxValue / 2;
            ushort adjustment = joystickX < neutral ? (ushort)((neutral - joystickX) >> 1) : (ushort)0;
            return scaleUShortToByte((ushort)(joystickY + adjustment));
        }

        public static byte canardLeft(ushort joystickY, ushort joystickX) {
            ushort neutral = ushort.MaxValue / 2;
            ushort adjustment = joystickX > neutral ? (ushort)((joystickX - neutral) >> 1) : (ushort)0;
            return (byte)(Byte.MaxValue - scaleUShortToByte((ushort)(joystickY + adjustment)));
        }

        public static byte rudder(bool rudderLeft, bool rudderRight, bool rudderReset) {
            if (rudderLeft)
                return Byte.MinValue;
            else if (rudderRight)
                return Byte.MaxValue;
            else
                return Byte.MaxValue >> 1;
        }

        public static byte airbrake(bool airbrake) {
            // logic for airbrake linear curve,
            // cause using it as a bool would be way to snappy
            if (airbrake) {
                if (airbrakeValue < byte.MaxValue)
                    airbrakeValue += 3;
            }
            else {
                if (airbrakeValue > 0)
                    airbrakeValue -= 3;
            }

            return airbrakeValue;
        }

        public static byte lights(bool positionLights, bool strobeLights, bool landingLight) {
            byte packed = (byte)(
                (positionLights ? 1 : 0) << 0 |
                (strobeLights ? 1 : 0) << 1 |
                (landingLight ? 1 : 0) << 2
            );
            return packed;
        }

        private static byte scaleUShortToByte(ushort value) {
            // linear transformation: 65535 / 255 = 257 exactly
            byte scaled = (byte)(value / 257);
            return scaled;
        }

    }
}
