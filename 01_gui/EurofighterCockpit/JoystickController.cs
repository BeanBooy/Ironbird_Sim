using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput;


namespace EurofighterCockpit
{
    internal class JoystickController
    {
        //DirectInput directInput;
        private Joystick joystick;
        private Joystick throttle;

        // logger
        private readonly Logger logger = Logger.Instance;

        public void initializeJoystick() {
            try {
                DirectInput directInput = new DirectInput();
                DeviceInstance joystickDI = null;
                DeviceInstance throttleDI = null;

                // loop over all devices to find joystick and throttle
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)) {
                    if (deviceInstance.ProductName.Contains("Joystick"))
                        joystickDI = deviceInstance;
                    else if (deviceInstance.ProductName.Contains("Throttle"))
                        throttleDI = deviceInstance;
                }

                if (joystickDI == null || throttleDI == null) {
                    if (joystickDI == null) {
                        logger.log("No joystick device found.");
                    }
                    if (throttleDI == null) {
                        logger.log("No throttle device found.");
                    }
                    return;
                }
                // connect to joystick device
                if (joystickDI == null) {
                    logger.log("No joystick device found.");
                }
                else {
                    joystick = new Joystick(directInput, joystickDI.InstanceGuid);
                    joystick.Acquire();
                    logger.log($"connected to JOYSTICK device ({joystickDI.InstanceName})");
                }
                // conenct to throttle device
                if (throttleDI == null) {
                    logger.log("No throttle device found.");
                }
                else {
                    throttle = new Joystick(directInput, throttleDI.InstanceGuid);
                    throttle.Acquire();
                    logger.log($"connected to THROTTLE device ({throttleDI.InstanceName})");
                }
            }
            catch (Exception ex) {
                logger.log($"ERROR while connecting to input device: {ex.ToString()}");
            }
        }

        public JoystickData poll() {

            var stateJoystick = joystick.GetCurrentState();
            var stateThrottle = throttle.GetCurrentState();

            ushort xValueRaw = Convert.ToUInt16(stateJoystick.X);
            ushort yValueRaw = Convert.ToUInt16(stateJoystick.Y);
            ushort rzValueRaw = Convert.ToUInt16(stateJoystick.TorqueY);  // ???
            bool airbrake = stateJoystick.Buttons[3];
            bool trigger = stateJoystick.Buttons[0];

            ushort throttleRaw = Convert.ToUInt16(stateThrottle.RotationZ);
            var rudderLeft = stateThrottle.Buttons[8];
            var rudderRight = stateThrottle.Buttons[9];
            var rudderReset = stateThrottle.Buttons[14];

            bool sound = stateThrottle.Buttons[19];

            return new JoystickData(xValueRaw, yValueRaw, rzValueRaw, airbrake, trigger, 
                throttleRaw, rudderLeft, rudderRight, rudderReset, sound);
        }
        
    }
}
