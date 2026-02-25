using SharpDX;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EurofighterCockpit
{
    internal class JoystickController
    {
        DirectInput directInput = new DirectInput();
        private Joystick joystick = null;
        private Joystick throttle = null;

        private CheckBox joystickStatus = null;
        private CheckBox throttleStatus = null;
        public readonly Color colGreen = Color.FromArgb(132, 189, 0);
        public readonly Color colRed = Color.FromArgb(228, 0, 43);

        // logger
        private readonly Logger logger = Logger.Instance;

        public JoystickController(CheckBox joystickStatus, CheckBox throttleStatus) {
            this.joystickStatus = joystickStatus;
            this.throttleStatus = throttleStatus;
        }

        private DeviceInstance getMatchingInputDevice(string filter) {
            // loop over all devices to find joystick and throttle
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)) {
                if (deviceInstance.ProductName.Contains(filter))
                    return deviceInstance;
            }
            return null;
        }

        public void initJoystick() {
            if (joystick != null) return;
            // get joystick device
            DeviceInstance joystickDI = getMatchingInputDevice("Joystick");
            // connect to joystick device
            if (joystickDI == null) {
                logger.log("No joystick device found.");
                joystickStatus.BackColor = colRed;
                return;
            }
            // aquire joystick device
            try {
                joystick = new Joystick(directInput, joystickDI.InstanceGuid);
                joystick.Acquire();
                logger.log($"joystick device '{joystickDI.InstanceName}' successfully connected");
                joystickStatus.BackColor = colGreen;
            }
            catch (Exception ex) {
                logger.log($"ERROR while connecting to joystick: {ex.ToString()}");
                joystickStatus.BackColor = colRed;
            }
        }

        public void initThrottle() {
            if (throttle != null) return;
            // get throttle device
            DeviceInstance throttleDI = getMatchingInputDevice("Throttle");
            // conenct to throttle device
            if (throttleDI == null) {
                logger.log("No throttle device found");
                throttleStatus.BackColor = colRed;
                return;
            }
            // aquire throttle device
            try {
                throttle = new Joystick(directInput, throttleDI.InstanceGuid);
                throttle.Acquire();
                logger.log($"throttle device '{throttleDI.InstanceName}' successfully connected");
                throttleStatus.BackColor = colGreen;
            }
            catch (Exception ex) {
                logger.log($"ERROR while connecting to throttle: {ex.ToString()}");
                throttleStatus.BackColor = colRed;
            }
        }

        public JoystickData poll() {
            JoystickData data = new JoystickData();
            // read out joystick input
            try {
                JoystickState stateJoystick = joystick?.GetCurrentState();
                if (stateJoystick != null) {
                    data.JoystickX = Convert.ToUInt16(stateJoystick.X);
                    data.JoystickY = Convert.ToUInt16(stateJoystick.Y);
                    data.JoystickTorque = Convert.ToUInt16(stateJoystick.TorqueY);  // ???
                    data.Airbrake = stateJoystick.Buttons[3];
                    data.Trigger = stateJoystick.Buttons[0];
                }
            }
            catch (SharpDXException ex) {
                if (ex.ResultCode == ResultCode.InputLost || ex.ResultCode == ResultCode.NotAcquired) {
                    logger.log($"joystick device '{joystick.Properties.InstanceName}' disconnected");
                    joystickStatus.BackColor = colRed;
                    joystick?.Dispose();
                    joystick = null;
                }
            }
            // read out throttle input
            try {
                JoystickState stateThrottle = throttle?.GetCurrentState();
                if (stateThrottle != null) {
                    data.Throttle = Convert.ToUInt16(stateThrottle.RotationZ);
                    data.RudderLeft = stateThrottle.Buttons[8];
                    data.RudderRight = stateThrottle.Buttons[9];
                    data.RudderReset = stateThrottle.Buttons[14];
                    data.Sound = stateThrottle.Buttons[19];
                    data.LandingGear = stateThrottle.Buttons[16];
                    data.PositionalLights = stateThrottle.Buttons[23];
                    data.StrobeLights = stateThrottle.Buttons[24];
                    data.LandingLights = stateThrottle.Buttons[15];
                }
            }
            catch (SharpDXException ex) {
                if (ex.ResultCode == ResultCode.InputLost || ex.ResultCode == ResultCode.NotAcquired) {
                    logger.log($"throttle device '{throttle.Properties.InstanceName}' disconnected");
                    throttleStatus.BackColor = colRed;
                    throttle?.Dispose();
                    throttle = null;
                }
            }

            return data;
        }
        
    }
}
