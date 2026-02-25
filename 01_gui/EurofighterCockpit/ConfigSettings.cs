using EurofighterCockpit.Slides;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class ConfigSettings : Form
    {
        // colors
        public readonly Color colGreen = Color.FromArgb(132, 189, 0);
        public readonly Color colRed = Color.FromArgb(228, 0, 43);
        public readonly Color colBlue = Color.FromArgb(0, 174, 199);

        // logger
        private readonly Logger logger = Logger.Instance;

        // network
        private TcpConnectionManager tcpCon;

        // controller
        private JoystickController joystickController;
        private Timer timer;
        private JoystickData prevData = new JoystickData();  // needed to skip updates when data == prevData
        private byte[] prevPayload = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // screens
        private Screen[] screens;
        private int screenCount;
        private bool showScreenIndicator;
        private ScreenIndicator[] screenIndicators;

        // windows
        private VideoPlayer videoPlayer;
        private Infotainment infotainment;
        private Infotainment infotainmentSub;

        // window indices
        private int videoPlayerScreenIndex = 0;
        private int infotainmentScreenIndex = 0;
        private int infotainmentSubScreenIndex = 0;

        // video
        private const string defaultVideoPath = "E:\\Dev\\Ironbird_Sim\\demoVid.mp4";
        private string videoPath;

        // eurofighter
        private int mode = 1;  // 0: sleep, 1: normal opperation, 2: servo test
        private bool sleep;
        private bool useController;

        // properties
        public bool ShowScreenIndicator { 
            get => showScreenIndicator;
            set { 
                showScreenIndicator = value;
                toggleScreenIndicator();
            }
        }
        public string VideoPath {
            get => videoPath;
            set {
                videoPath = value;
                tb_videoFilePath.Text = value;
                cb_videoPathValid.BackColor = File.Exists(value) ? colGreen : colRed;
                videoPlayer?.setSource(value);
            }
        }

        public int Mode {
            get => mode;
            set {
                mode = value;
                if (mode == 0)
                    timer.Enabled = false;
                else
                    timer.Enabled = true;
            }
        }

        public ConfigSettings() {
            InitializeComponent();
            logger.setLogBox(tb_logs);
        }

        private void ConfigSettings_Load(object sender, EventArgs e) {

            // initialize screens
            screens = Screen.AllScreens;
            screenCount = screens.Length;
            screenIndicators = new ScreenIndicator[screenCount];
            for (int i = 0; i < screenCount; i++) {
                screenIndicators[i] = new ScreenIndicator(screens[i], i);
            }

            // launch windows    ######### TODO: move to LibVLCSharp instead of MediaPlayer
            videoPlayer = launchWindow(ref videoPlayer, videoPlayerScreenIndex, bt_videoPlayer, vp => {
                VideoPath = VideoPath == null ? defaultVideoPath : VideoPath;
                vp.setSource(VideoPath);
            });
            infotainment = launchWindow(ref infotainment, infotainmentScreenIndex, bt_infotainment);
            infotainmentSub = launchWindow(ref infotainmentSub, infotainmentSubScreenIndex, bt_infotainmentSub, inf => inf.hidePanel());

            populateScreenSelectors(tlp_videoPlayer, videoPlayer, screenCount);
            populateScreenSelectors(tlp_infotainment, infotainment, screenCount);
            populateScreenSelectors(tlp_infotainmentSub, infotainmentSub, screenCount);

            // initialize the joysticks
            joystickController = new JoystickController(cb_joystickConnected, cb_throttleConnected);
            joystickController.initJoystick();
            joystickController.initThrottle();

            // controller polling
            timer = new Timer();
            timer.Interval = 30;  // ms
            timer.Tick += Timer_Tick;
            timer.Start();

            // connection loop for raspberry  ##### TODO: config file for ip and port
            tcpCon = new TcpConnectionManager("192.168.178.65", 4443);
            //tcpCon = new TcpConnectionManager("192.168.178.80", 4443);
            tcpCon.ConnectionStatusChanged += onConnectionStatusChanged;
            tcpCon.start();

            logger.logToBox("...ready!");

            // testing section !!!!!!!!!!!

            infotainment.ShowSlide(new Slide1());
            //servoDisplay1.setValue(90);

        }

        private void Timer_Tick(object sender, EventArgs e) {
            // fetch
            JoystickData data = joystickController.poll();
            updateControllerDisplay(data);
            // build payload
            byte[] payload = buildPayload(data);
            updateServoDisplay(payload);
            // send to the pi
            validateAndSendPayload(payload);
        }

        private void validateAndSendPayload(byte[] payload) {
            if (Mode == 0) return;
            // check if previous payload differs
            // if it's exactly the same, don't send new data
            if (Enumerable.SequenceEqual(payload, prevPayload))
                return;
            prevPayload = (byte[])payload.Clone();
            tcpCon.sendAsync(payload, bt_showNetworkTraffic.IsChecked);
        }

        private void updateServoDisplay(byte[] payload) {
            sd_canardLeft.Value = payload[1];
            sd_canardRight.Value = payload[2];
            sd_aileronLeft.Value = payload[3];
            sd_aileronRight.Value = payload[4];
            sd_flapLeft.Value = payload[5];
            sd_flapRight.Value = payload[6];
            sd_airbrake.Value = payload[7];
            sd_gear.Value = payload[8];
        }

        private void updateControllerDisplay(JoystickData data) {
            bpb_airbrakeCurve.Progress = Convert.ToInt32(EurofighterControl.AirbrakeValue * 100 / byte.MaxValue);
            // check if dataset is the same to prevent ui update spamming
            if (data.Equals(prevData))
                return;
            prevData = data;
            // update all elements
            bpb_joystickXpos.Progress = Convert.ToInt32(data.JoystickXPercent * 100);
            bpb_joystickXneg.Progress = Convert.ToInt32(data.JoystickXPercent * -100);
            bpb_joystickYpos.Progress = Convert.ToInt32(data.JoystickYPercent * 100);
            bpb_joystickYneg.Progress = Convert.ToInt32(data.JoystickYPercent * -100);
            bpb_joystickTorque.Progress = Convert.ToInt32(data.JoystickTorquePercent * 100);
            bpb_airbrake.Progress = data.Airbrake ? 100 : 0;
            //bpb_airbrake.Progress = 0;  // TODO: airbrake trigger curve
            bpb_throttle.Progress = Convert.ToInt32(data.ThrottlePercent * 100);
            bpb_trigger.Progress = data.Trigger ? 100 : 0;
            bpb_sound.Progress = data.Sound ? 100 : 0;
            bpb_rudderL.Progress = data.RudderLeft ? 100 : 0;
            bpb_rudderR.Progress = data.RudderRight ? 100 : 0;
            bpb_rudderReset.Progress = data.RudderReset ? 100 : 0;
            bpb_gear.Progress = data.LandingGear ? 100 : 0;
            bpb_positionLights.Progress = data.PositionalLights ? 100 : 0;
            bpb_strobeLights.Progress = data.StrobeLights ? 100 : 0;
            bpb_landingLights.Progress = data.LandingLights ? 100 : 0;
        }

        private byte[] buildPayload(JoystickData data) {
            return new byte[] {
                Convert.ToByte(Mode),
                EurofighterControl.canardLeft(data.JoystickY, data.JoystickX),
                EurofighterControl.canardRight(data.JoystickY, data.JoystickX),
                EurofighterControl.aileronLeft(data.JoystickX, data.JoystickY),
                EurofighterControl.aileronRight(data.JoystickX, data.JoystickY),
                EurofighterControl.flapLeft(data.JoystickY),
                EurofighterControl.flapRight(data.JoystickY),
                EurofighterControl.airbrake(data.Airbrake),
                Convert.ToByte(data.LandingGear),
                EurofighterControl.lights(data.PositionalLights, data.StrobeLights, data.LandingLights),
                0,
                0,
                0,
                0,
                0,
                0
            };
        }

        private T launchWindow<T>(ref T window, int screenIndex, BetterToggle toggleButton, Action<T> postInit = null) where T : Form, new() {
            if (window != null) return window;
            window = new T();
            window.Load += (s, e) => { toggleButton.IsChecked = true; };
            // capture window in local variable for safe closure
            Form localWindow = window;
            window.FormClosed += (s, e) => {
                toggleButton.IsChecked = false;
                // set the correct field to null
                if (localWindow == videoPlayer) videoPlayer = null;
                else if (localWindow == infotainment) infotainment = null;
                else if (localWindow == infotainmentSub) infotainmentSub = null;
            };
            moveWindowToScreen(window, screenIndex);
            postInit?.Invoke(window); // optional additional code
            window.Show();
            logger.log($"{window.GetType().Name} launched!");
            return window;
        }

        private void toggleScreenIndicator() {
            if (ShowScreenIndicator) {
                Array.ForEach(screenIndicators, obj => obj.Show());
            }
            else {
                Array.ForEach(screenIndicators, obj => obj.Hide());
            }
        }

        private void populateScreenSelectors(TableLayoutPanel tly, Form form, int columns) {
            // should be 3 screens/columns for perfect setup,
            // but why hardcode it if a dynamic complicated solution is possible ;)
            tly.Controls.Clear();
            tly.RowStyles.Clear();
            tly.ColumnStyles.Clear();
            tly.RowCount = 1;
            tly.ColumnCount = columns;
            tly.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            // create columns
            for (int i = 0; i < columns; i++) {
                RadioButton rb = new RadioButton();
                rb.Text = i.ToString();
                rb.Dock = DockStyle.Fill;
                rb.TextAlign = ContentAlignment.MiddleCenter;
                rb.Appearance = Appearance.Button;
                rb.BackColor = Color.FromName("Control");
                rb.FlatStyle = FlatStyle.Flat;
                rb.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 174, 199);
                rb.FlatAppearance.BorderSize = 1;
                rb.Click += new EventHandler(anyScreenSelector_Click);
                // add radio button to parent and justify the width
                tly.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));
                tly.Controls.Add(rb, i, 0);
            }
            // select first one automatically
            ((RadioButton)tly.Controls[0]).Checked = true;
        }

        private void moveWindowToScreen(Form form, int screenIndex) {
            if (form == null || screenIndex < 0 || screenIndex >= screens.Length) return;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = screens[screenIndex].WorkingArea.Location;
        }

        #region event handler
        private void bt_showSceenIndicators_UserClick(object sender, EventArgs e) {
            ShowScreenIndicator = bt_showSceenIndicators.IsChecked;
        }

        private void bt_videoPlayer_UserClick(object sender, EventArgs e) {
            if (videoPlayer == null)
                videoPlayer = launchWindow(ref videoPlayer, videoPlayerScreenIndex, bt_videoPlayer, vp => vp.setSource(VideoPath));
            else
                videoPlayer.Close();
        }

        private void bt_infotainment_UserClick(object sender, EventArgs e) {
            if (infotainment == null)
                infotainment = launchWindow(ref infotainment, infotainmentScreenIndex, bt_infotainment);
            else
                infotainment.Close();
        }

        private void bt_infotainmentSub_UserClick(object sender, EventArgs e) {
            if (infotainmentSub == null)
                infotainmentSub = launchWindow(ref infotainmentSub, infotainmentSubScreenIndex, bt_infotainmentSub, inf => inf.hidePanel());
            else
                infotainmentSub.Close();
        }

        private void anyScreenSelector_Click(object sender, EventArgs e) {
            RadioButton rb = sender as RadioButton;
            int screenIndex = Convert.ToInt32(rb.Text);
            if (rb.Parent == tlp_videoPlayer) {
                videoPlayerScreenIndex = screenIndex;
                moveWindowToScreen(videoPlayer, screenIndex);
                videoPlayer.Activate();  // bring to focus
            }
            if (rb.Parent == tlp_infotainment) {
                infotainmentScreenIndex = screenIndex;
                moveWindowToScreen(infotainment, infotainmentScreenIndex);
                infotainment.Activate();  // bring to focus
            }
            if (rb.Parent == tlp_infotainmentSub) {
                infotainmentSubScreenIndex = screenIndex;
                moveWindowToScreen(infotainmentSub, infotainmentSubScreenIndex);
                infotainmentSub.Activate();  // bring to focus
            }
        }

        private void btn_browseVideoFile_Click(object sender, EventArgs e) {
            // open file dialog to select video file
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = "E:\\Dev\\Ironbird_Sim";  // TODO: setup for final version
                ofd.Filter = "mp4 files (*.mp4)|*.mp4";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;
                ofd.AutoUpgradeEnabled = false;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    VideoPath = ofd.FileName;
                }
            }
        }

        protected override void WndProc(ref Message m) {
            // overwrite WndProc to handle 'WM_DEVICECHANGE' to notice possible joystick device change
            const int WM_DEVICECHANGE = 0x0219;
            if (m.Msg == WM_DEVICECHANGE) {
                joystickController.initJoystick();
                joystickController.initThrottle();
            }
            base.WndProc(ref m);
        }

        private void onConnectionStatusChanged(bool connected) {
            // update info box ui according to pi connection status
            if (InvokeRequired) {
                Invoke(new Action(() => onConnectionStatusChanged(connected)));
                return;
            }
            cb_connectionState.Text = connected ? "CONNECTED" : "NOT CONNECTED";
            cb_connectionState.BackColor = connected ? colGreen : colRed;
        }

        private void ConfigSettings_FormClosing(object sender, FormClosingEventArgs e) {
            tcpCon?.Dispose();
        }

        private void servoOverright_ValueChanged(object sender, EventArgs e) {
            if (bt_useController.IsChecked)
                return;
            // create payload
            byte[] payload = new byte[16];
            payload[0] = 1;
            payload[1] = sd_canardLeft.Value;
            payload[2] = sd_canardRight.Value;
            payload[3] = sd_aileronLeft.Value;
            payload[4] = sd_aileronRight.Value;
            payload[5] = sd_flapLeft.Value;
            payload[6] = sd_flapRight.Value;
            payload[7] = sd_airbrake.Value;
            payload[8] = sd_gear.Value;
            // send to the pi
            validateAndSendPayload(payload);
        }

        private void bt_useController_UserClick(object sender, EventArgs e) {
            timer.Enabled = bt_useController.IsChecked;
        }

        private void bt_sleep_UserClick(object sender, EventArgs e) {
            if (bt_sleep.IsChecked) {
                byte[] payload = new byte[16];
                validateAndSendPayload(payload);
                Mode = 0;
            }
            else {
                Mode = 1;
            }
        }

        #endregion

    }
}
