using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    internal class JoystickData
    {
        // joystick
        public (ushort raw, double percent) joystickX;
        public (ushort raw, double percent) joystickY;
        public (ushort raw, double percent) joystickTorque;  // ???
        public bool airbrake;
        public bool trigger;

        // throttle
        public (ushort raw, double percent) throttle;
        public bool rudderLeft;
        public bool rudderRight;
        public bool rudderReset;

        public bool sound;

        public JoystickData(ushort joystickX, ushort joystickY, ushort joystickTorque, bool airbrake, bool trigger, ushort throttle, bool rudderLeft, bool rudderRight, bool rudderReset, bool sound) {
            this.joystickX = (joystickX, (Convert.ToDouble(joystickX) - ushort.MaxValue / 2) / ushort.MaxValue * 2);
            this.joystickY = (joystickY, (Convert.ToDouble(joystickY) - ushort.MaxValue / 2) / ushort.MaxValue * -2);
            this.joystickTorque = (joystickTorque, (joystickTorque - ushort.MaxValue / 2) / ushort.MaxValue);
            this.airbrake = airbrake;
            this.trigger = trigger;
            this.throttle = (throttle, (Convert.ToDouble(throttle) - ushort.MaxValue) / -ushort.MaxValue);
            this.rudderLeft = rudderLeft;
            this.rudderRight = rudderRight;
            this.rudderReset = rudderReset;
            this.sound = sound;


        }
    }
}
