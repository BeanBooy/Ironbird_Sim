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
        private const byte maxValue = byte.MaxValue;
        private const byte neutralValue = byte.MaxValue / 2;

        // flaps
        public static byte flapRight(ushort joystickY) {
            return scaleUShortToByte(joystickY);
        }

        public static byte flapLeft(ushort joystickY) {
            return (byte)(byte.MaxValue - scaleUShortToByte(joystickY));
        }

        //// ailerons
        //public static byte aileronRight(int joystickXValue, int joystickYValue) {
        //    if (joystickXValue > 80 && joystickXValue < 100) {
        //        return joystickYValue;
        //    }
        //    else {
        //        return joystickXValue;
        //    }
        //}

        //public static byte aileronLeft(int joystickXValue, int joystickYValue) {
        //    if (joystickXValue > 80 && joystickXValue < 100) {
        //        return 180 - joystickYValue;
        //    }
        //    else {
        //        return joystickXValue;
        //    }
        //}


        //// Canards
        //public static byte canardRight(int joystickYValue, int joystickXValue) {
        //    int adjustment = joystickXValue < NeutralValue ? (NeutralValue - joystickXValue) / 2 : 0;
        //    return joystickYValue + adjustment;
        //}

        //public static byte canardLeft(int joystickYValue, int joystickXValue) {
        //    int adjustment = joystickXValue > NeutralValue ? (joystickXValue - NeutralValue) / 2 : 0;
        //    return 180 - joystickYValue + adjustment;
        //}

        //// Seitenruder (Rudder)
        //public static byte rudder(int rudderTriggerValue) {
        //    return rudderTriggerValue;
        //}

        //// lighting
        //public static byte lights(bool positionLight, int landingLight) {

        //}


        private static byte scaleUShortToByte(ushort value) {
            // linear transformation: 65535 / 255 = 257 exactly
            byte scaled = (byte)(value / 257);
            return scaled;
        }

    }
}
