using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    internal class CockpitController
    {
        private readonly Logger logger = Logger.Instance;
        private readonly Config config = Config.Instance;

        private readonly JoystickController joystickController;
        private readonly TcpConnectionManager tcpConnection;
        private readonly Timer timer;

        private JoystickData previousData = new JoystickData();
        private byte[] previousPayload = new byte[16];

        private bool networkLog;
        private bool overwriteMode;
        private bool sleepMode;

        private bool isMovieRunning;
        private JoystickData[] movieInputs = null;
        private int movieInputPosition = 0;
        private Stopwatch timeKeeper;

        // events for ui
        public event Action<JoystickData> JoystickDataUpdated;
        public event Action<byte[]> PayloadUpdated;
        public event Action<bool> ConnectionStatusChanged;
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
            // read input file for the movie joystick movement
            ReadMovieInputFile(config.Dict["movieInputPath"]);
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

        private void OnTick(object sender, EventArgs e) {
            if (sleepMode) return;

            JoystickData data = GetInputData();

            if (!data.Equals(previousData)) {
                previousData = data;
                JoystickDataUpdated?.Invoke(data);
            }

            if (!overwriteMode) {
                var payload = BuildPayload(data);
                ValidateAndSend(payload);
            }
        }

        private JoystickData GetInputData() {
            // either return realtime joystick data or from movie file
            if (isMovieRunning && movieInputs != null) {
                if (movieInputPosition >= movieInputs.Length - 1) {
                    EndMovie();
                    return joystickController.Poll();
                }

                long realTime = timeKeeper.ElapsedMilliseconds;
                // advance position while next timestamp is still before realtime
                while (movieInputPosition < movieInputs.Length - 1 && 
                    movieInputs[movieInputPosition + 1].TimeInMs <= realTime) {
                    movieInputPosition++;
                }
                return movieInputs[movieInputPosition];
            }

            return joystickController.Poll();
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
                logger.Log("Eurofighter set to sleep");
            }
            else {
                Send(previousPayload);
                timer.Start();
                logger.Log("Eurofighter has woken up");
            }
        }

        public void StartServoTest() {
            var payload = new byte[16];
            payload[0] = 2;
            Send(payload);
            logger.Log("Servo test started");
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

        public void StartMovieSequence() {
            if (isMovieRunning)
                EndMovie();
            StartMovie();
        }

        private void ReadMovieInputFile(string path) {
            if (!File.Exists(path))
                return;
            string[] data = File.ReadAllLines(path);
            movieInputs = new JoystickData[data.Length];
            for (int i = 0; i < data.Length; i++) {
                movieInputs[i] = new JoystickData();
                string[] line = data[i].Split(',');
                movieInputs[i].TimeInMs = Convert.ToUInt32(line[0]);
                movieInputs[i].JoystickY = Convert.ToUInt16(line[1]);
                movieInputs[i].JoystickX = Convert.ToUInt16(line[2]);
                movieInputs[i].JoystickTorque = Convert.ToUInt16(line[3]);
                movieInputs[i].Airbrake = Convert.ToBoolean(Convert.ToInt32(line[4]));
                movieInputs[i].Trigger = Convert.ToBoolean(Convert.ToInt32(line[5]));
                movieInputs[i].RudderLeft = Convert.ToBoolean(Convert.ToInt32(line[6]));
                movieInputs[i].RudderRight = Convert.ToBoolean(Convert.ToInt32(line[7]));
                movieInputs[i].RudderReset = Convert.ToBoolean(Convert.ToInt32(line[8]));
                movieInputs[i].Throttle = Convert.ToUInt16(line[9]);
                movieInputs[i].LandingGear = Convert.ToBoolean(Convert.ToInt32(line[10]));
                movieInputs[i].LandingLights = Convert.ToBoolean(Convert.ToInt32(line[11]));
                movieInputs[i].PositionalLights = Convert.ToBoolean(Convert.ToInt32(line[12]));
            }
        }

        private void StartMovie() {
            isMovieRunning = true;
            timeKeeper = Stopwatch.StartNew();
            movieInputPosition = 0;
            logger.LogToBox("movie sequence started");
        }

        private void EndMovie() {
            isMovieRunning = false;
            timeKeeper = null;  // kill the stopwatch
            movieInputPosition = 0;
            logger.LogToBox("movie sequence ended");
        }

    }
}
