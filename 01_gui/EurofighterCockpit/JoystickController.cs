using SharpDX;
using SharpDX.DirectInput;
using System;

namespace EurofighterCockpit
{
    internal class JoystickController
    {
        DirectInput directInput = new DirectInput();
        private Joystick joystick = null;
        private Joystick throttle = null;

        //public readonly Color colGreen = Color.FromArgb(132, 189, 0);
        //public readonly Color colRed = Color.FromArgb(228, 0, 43);

        public event Action<bool> JoystickConnectionChanged;
        public event Action<bool> ThrottleConnectionChanged;

        private readonly Logger logger = Logger.Instance;

        private DeviceInstance GetMatchingInputDevice(string filter) {
            // loop over all devices to find joystick and throttle
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)) {
                if (deviceInstance.ProductName.Contains(filter))
                    return deviceInstance;
            }
            return null;
        }

        public void InitJoystick() {
            if (joystick != null) return;
            // get joystick device
            DeviceInstance joystickDI = GetMatchingInputDevice("Joystick");
            // connect to joystick device
            if (joystickDI == null) {
                logger.Log("No joystick device found.");
                JoystickConnectionChanged?.Invoke(false);
                return;
            }
            // aquire joystick device
            try {
                joystick = new Joystick(directInput, joystickDI.InstanceGuid);
                joystick.Acquire();
                logger.Log($"joystick device '{joystickDI.InstanceName}' successfully connected");
                JoystickConnectionChanged?.Invoke(true);
            }
            catch (Exception ex) {
                logger.Log($"ERROR while connecting to joystick: {ex.ToString()}");
                JoystickConnectionChanged?.Invoke(false);
            }
        }

        public void InitThrottle() {
            if (throttle != null) return;
            // get throttle device
            DeviceInstance throttleDI = GetMatchingInputDevice("Throttle");
            // conenct to throttle device
            if (throttleDI == null) {
                logger.Log("No throttle device found");
                ThrottleConnectionChanged?.Invoke(false);
                return;
            }
            // aquire throttle device
            try {
                throttle = new Joystick(directInput, throttleDI.InstanceGuid);
                throttle.Acquire();
                logger.Log($"throttle device '{throttleDI.InstanceName}' successfully connected");
                ThrottleConnectionChanged?.Invoke(true);
            }
            catch (Exception ex) {
                logger.Log($"ERROR while connecting to throttle: {ex.ToString()}");
                ThrottleConnectionChanged?.Invoke(false);
            }
        }

        public JoystickData Poll() {
            JoystickData data = new JoystickData();
            // get joystick input
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
                    logger.Log($"joystick device '{joystick.Properties.InstanceName}' disconnected");
                    JoystickConnectionChanged?.Invoke(false);
                    joystick?.Dispose();
                    joystick = null;
                }
            }
            // get throttle input
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
                    logger.Log($"throttle device '{throttle.Properties.InstanceName}' disconnected");
                    ThrottleConnectionChanged?.Invoke(false);
                    throttle?.Dispose();
                    throttle = null;
                }
            }

            return data;
        }
        
    }
}
