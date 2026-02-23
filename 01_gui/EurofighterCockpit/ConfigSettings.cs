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
        public readonly Color colRed = Color.FromName("Crimson");
        public readonly Color colGreen = Color.FromArgb(40, 209, 43);

        // logger
        private readonly Logger logger = Logger.Instance;

        // network
        private TcpConnectionManager tcpCon;

        // controller
        private JoystickController joystickController;
        private Timer timer;
        private JoystickData prevData = new JoystickData();  // needed to skip updates when data == prevData

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
                tb_videoFilePath.BackColor = File.Exists(value) ? Color.FromName("Control") : colRed;
                videoPlayer?.setSource(value);
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
            videoPlayer = launchWindow(ref videoPlayer, videoPlayerScreenIndex, btn_videoPlayer, vp => {
                VideoPath = VideoPath == null ? defaultVideoPath : VideoPath;
                vp.setSource(VideoPath);
            });
            infotainment = launchWindow(ref infotainment, infotainmentScreenIndex, btn_infotainment);
            infotainmentSub = launchWindow(ref infotainmentSub, infotainmentSubScreenIndex, btn_infotainmentSub, inf => inf.hidePanel());

            populateScreenSelectors(tlp_videoPlayer, videoPlayer, screenCount);
            populateScreenSelectors(tlp_infotainment, infotainment, screenCount);
            populateScreenSelectors(tlp_infotainmentSub, infotainmentSub, screenCount);

            // initialize the joysticks
            joystickController = new JoystickController();
            joystickController.initJoystick();
            joystickController.initThrottle();

            // controller polling
            timer = new Timer();
            timer.Interval = 10;  // 10ms
            timer.Tick += Timer_Tick;
            timer.Start();

            // connection loop for raspberry  ##### TODO: config file for ip and port
            tcpCon = new TcpConnectionManager("192.168.178.65", 4443);
            tcpCon.ConnectionStatusChanged += onConnectionStatusChanged;
            tcpCon.start();

            logger.logToBox("...ready!");

            // testing section !!!!!!!!!!!

            infotainment.ShowSlide(new Slide1());

        }

        byte[] prevPayload = new byte[0];
        private void Timer_Tick(object sender, EventArgs e) {
            JoystickData data = joystickController.poll();
            
            updateUiWithInputData(data);

            // build payload
            byte[] payload = preparePayload(data);
            // check if previous payload differs
            // if it's exactly the same, don't send new data
            if (Enumerable.SequenceEqual(payload, prevPayload))
                return;
            prevPayload = payload;

            logger.logToBox(
                string.Join(", ", payload.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')))
            );
            bool logPayload = ck_showNetworkTraffic.Checked;
            tcpCon.sendAsync(payload, logPayload);
        }

        private void updateUiWithInputData(JoystickData data) {
            // check if dataset is the same to prevent ui update spamming
            if (data.Equals(prevPayload))
                return;
            prevData = data;
            // update all elements
            bpb_joystickXpos.Progress = Convert.ToInt32(data.JoystickXPercent * 100);
            bpb_joystickXneg.Progress = Convert.ToInt32(data.JoystickXPercent * -100);
            bpb_joystickYpos.Progress = Convert.ToInt32(data.JoystickYPercent * 100);
            bpb_joystickYneg.Progress = Convert.ToInt32(data.JoystickYPercent * -100);
            bpb_joystickTorque.Progress = Convert.ToInt32(data.JoystickTorquePercent * 100);
            bpb_airbrakeBool.Progress = data.Airbrake ? 100 : 0;
            bpb_airbrake.Progress = 0;  // TODO: airbrake trigger curve
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

        private byte[] preparePayload(JoystickData data) {
            return new byte[] {
                1,  // TODO
                EurofighterControl.canardLeft(data.JoystickY, data.JoystickX),
                EurofighterControl.canardRight(data.JoystickY, data.JoystickX),
                EurofighterControl.aileronLeft(data.JoystickX, data.JoystickY),
                EurofighterControl.aileronRight(data.JoystickX, data.JoystickY),
                EurofighterControl.flapLeft(data.JoystickY),
                EurofighterControl.flapRight(data.JoystickY),
                0,  // TODO airbrake
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

        private T launchWindow<T>(ref T window, int screenIndex, Button toggleButton, Action<T> postInit = null) where T : Form, new() {
            if (window != null) return window;
            window = new T();
            window.Load += (s, e) => toggleBtn(toggleButton, true);
            // capture window in local variable for safe closure
            Form localWindow = window;
            window.FormClosed += (s, e) => {
                toggleBtn(toggleButton, false);
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

        private void toggleBtn(Button btn, bool state) {
            btn.BackColor = state ? colGreen : colRed;
            btn.Text = state ? "ON" : "OFF";
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
                rb.FlatAppearance.CheckedBackColor = Color.Orange;
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
        private void screenIndicator_CheckedChanged(object sender, EventArgs e) {
            ShowScreenIndicator = screenIndicator.Checked;
        }

        private void anyWindowToggle_Click(object sender, EventArgs e) {
            if (sender == btn_videoPlayer) {
                if (videoPlayer == null) {
                    videoPlayer = launchWindow(ref videoPlayer, videoPlayerScreenIndex, btn_videoPlayer, vp => vp.setSource(VideoPath));
                }
                else {
                    videoPlayer.Close();
                }
            }
            else if (sender == btn_infotainment) {
                if (infotainment == null) {
                    infotainment = launchWindow(ref infotainment, infotainmentScreenIndex, btn_infotainment);
                }
                else {
                    infotainment.Close();
                }
            }
            else if (sender == btn_infotainmentSub) {
                if (infotainmentSub == null) {
                    infotainmentSub = launchWindow(ref infotainmentSub, infotainmentSubScreenIndex, btn_infotainmentSub, inf => inf.hidePanel());
                }
                else {
                    infotainmentSub.Close();
                }
            }
        }

        private void anyScreenSelector_Click(object sender, EventArgs e) {
            RadioButton rb = sender as RadioButton;
            int screenIndex = Convert.ToInt32(rb.Text);
            if (rb.Parent == tlp_videoPlayer) {
                videoPlayerScreenIndex = screenIndex;
                moveWindowToScreen(videoPlayer, screenIndex);
            }
            if (rb.Parent == tlp_infotainment) {
                infotainmentScreenIndex = screenIndex;
                moveWindowToScreen(infotainment, infotainmentScreenIndex);
            }
            if (rb.Parent == tlp_infotainmentSub) {
                infotainmentSubScreenIndex = screenIndex;
                moveWindowToScreen(infotainmentSub, infotainmentSubScreenIndex);
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
            cb_connectionState.Text = connected ? "Connected" : "Not Connected";
            cb_connectionState.BackColor = connected ? colGreen : colRed;
        }

        private void ConfigSettings_FormClosing(object sender, FormClosingEventArgs e) {
            tcpCon?.Dispose();
        }

        #endregion

    }
}
