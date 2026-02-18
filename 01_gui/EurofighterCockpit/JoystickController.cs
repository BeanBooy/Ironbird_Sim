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
        DirectInput directInput;
        private Joystick joystick;
        private Joystick throttle;

        // logger
        private readonly Logger logger = new Logger();

        public void initializeJoystick() {
            try {
                directInput = new DirectInput();
                var joystickGuid = Guid.Empty;
                var throttleGuid = Guid.Empty;

                // loop over all devices to find joystick and throttle
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)) {
                    if (deviceInstance.ProductName.Contains("Joystick"))
                        joystickGuid = deviceInstance.InstanceGuid;
                    else if (deviceInstance.ProductName.Contains("Throttle"))
                        throttleGuid = deviceInstance.InstanceGuid;
                }

                if (joystickGuid == Guid.Empty) {
                    Console.WriteLine("Joystick nicht verbunden!");
                }
                if (throttleGuid == Guid.Empty) {
                    Console.WriteLine("Throttle nicht verbunden!");
                }

                // get the instances
                if (joystickGuid != Guid.Empty) {
                    joystick = new Joystick(directInput, joystickGuid);
                    joystick.Acquire();
                }
                if (throttleGuid != Guid.Empty) {
                    throttle = new Joystick(directInput, throttleGuid);
                    throttle.Acquire();
                }
                
            }
            catch (Exception ex) {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                string severity = ex.GetType().Name;
                logger.log($"{methodName}: {severity} - {ex.ToString()}");
            }
        }

        public JoystickData poll() {
            if (joystick != null) {
                joystick.Poll();
            }

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
