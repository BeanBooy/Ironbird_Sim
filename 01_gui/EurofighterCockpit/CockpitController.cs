using System;
using System.Linq;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    internal class CockpitController
    {
        private readonly Logger logger = Logger.Instance;

        private readonly JoystickController joystickController;
        private readonly TcpConnectionManager tcpConnection;
        private readonly Timer timer;

        private JoystickData previousData = new JoystickData();
        private byte[] previousPayload = new byte[16];

        private bool networkLog;
        private bool overwriteMode;
        private bool sleepMode;

        // events for ui
        public event Action<JoystickData> JoystickDataUpdated;
        public event Action<byte[]> PayloadUpdated;
        public event Action<bool> ConnectionStatusChanged;
        public event Action<string> LogMessage;
        public event Action<bool> JoystickConnectionChanged;
        public event Action<bool> ThrottleConnectionChanged;

        public CockpitController(string ip, string port) {
            // setup joystick controller with event forwarding
            joystickController = new JoystickController();
            joystickController.JoystickConnectionChanged += connected => JoystickConnectionChanged?.Invoke(connected);
            joystickController.ThrottleConnectionChanged += connected => ThrottleConnectionChanged?.Invoke(connected);
            // setup TCP controller with event forwarding
            try {
                tcpConnection = new TcpConnectionManager(ip, Convert.ToInt32(port));
                tcpConnection.ConnectionStatusChanged += connected => ConnectionStatusChanged?.Invoke(connected);
            }
            catch (Exception ex) {
                logger.Log("ERROR in TCP connection: Please check your network configuration");
                logger.LogToFile(ex.Message);
            }
            // setup joystick polling timer
            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += OnTick;
        }

        public void Start() {
            joystickController.InitJoystick();
            joystickController.InitThrottle();
            tcpConnection?.Start();
            timer.Start();
        }

        public void Stop() {
            timer.Stop();
        }

        private void OnTick(object sender, EventArgs e) {
            if (sleepMode) return;

            var data = joystickController.Poll();

            if (!data.Equals(previousData)) {
                previousData = data;
                JoystickDataUpdated?.Invoke(data);
            }

            if (!overwriteMode) {
                var payload = BuildPayload(data);
                ValidateAndSend(payload);
            }
        }

        private byte[] BuildPayload(JoystickData data) {
            return new byte[] {
                1,
                EurofighterControl.CanardLeft(data.JoystickY),
                EurofighterControl.CanardRight(data.JoystickY),
                EurofighterControl.AileronLeft(data.JoystickX, data.JoystickY),
                EurofighterControl.AileronRight(data.JoystickX, data.JoystickY),
                EurofighterControl.FlapLeft(data.JoystickX, data.JoystickY),
                EurofighterControl.FlapRight(data.JoystickX, data.JoystickY),
                EurofighterControl.Airbrake(data.Airbrake),
                EurofighterControl.Rudder(data.RudderLeft, data.RudderRight, data.RudderReset),
                Convert.ToByte(data.LandingGear),
                EurofighterControl.Lights(
                    data.PositionalLights,
                    data.StrobeLights,
                    data.LandingLights),
                0,0,0,0,0
            };
        }

        private void ValidateAndSend(byte[] payload) {
            if (Enumerable.SequenceEqual(payload.Skip(1), previousPayload.Skip(1)))
                return;

            previousPayload = (byte[])payload.Clone();
            Send(payload);
        }

        public void SendManualPayload(byte[] payload) {
            ValidateAndSend(payload);
        }

        private async void Send(byte[] payload) {
            if (tcpConnection == null)
                return;
            PayloadUpdated?.Invoke(payload);
            await tcpConnection.SendAsync(payload, networkLog);
        }

        public void EnableNetworkLog(bool enabled) {
            networkLog = enabled;
        }

        public void EnableOverwrite(bool enabled) {
            overwriteMode = enabled;
        }

        public void EnableSleepMode(bool enabled) {
            sleepMode = enabled;

            if (enabled) {
                var zeroPayload = new byte[16];
                Send(zeroPayload);
                timer.Stop();
                LogMessage?.Invoke("Eurofighter set to sleep");
            }
            else {
                Send(previousPayload);
                timer.Start();
                LogMessage?.Invoke("Eurofighter woken up");
            }
        }

        public void StartServoTest() {
            var payload = new byte[16];
            payload[0] = 2;
            Send(payload);
            LogMessage?.Invoke("Servo test started");
        }

        public void ReinitializeDevices() {
            joystickController.InitJoystick();
            joystickController.InitThrottle();
        }

        public void Dispose() {
            var zeroPayload = new byte[16];
            Send(zeroPayload);
            timer?.Stop();
            tcpConnection?.Dispose();
        }

    }
}
