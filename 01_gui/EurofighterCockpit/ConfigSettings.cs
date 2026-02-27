using EurofighterCockpit.Slides;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class ConfigSettings : Form
    {
        public readonly Color colGreen = Color.FromArgb(132, 189, 0);
        public readonly Color colRed = Color.FromArgb(228, 0, 43);
        public readonly Color colBlue = Color.FromArgb(0, 174, 199);

        // controller
        private CockpitController controller;

        private readonly Logger logger = Logger.Instance;
        private readonly Config config = Config.Instance;
        
        // screens
        private Screen[] screens;
        private int screenCount;
        private bool showScreenIndicator;
        private ScreenIndicator[] screenIndicators;

        // windows
        private VideoPlayer videoPlayer;
        private Infotainment infotainment;
        private Infotainment infotainmentSub;
        private int videoPlayerScreenIndex = 0;
        private int infotainmentScreenIndex = 0;
        private int infotainmentSubScreenIndex = 0;

        // slides
        private BaseSlide[] mainSlides = null;
        private BaseSlide[] subSlides = null;

        // properties
        public bool ShowScreenIndicator { 
            get => showScreenIndicator;
            set { 
                showScreenIndicator = value;
                toggleScreenIndicator();
            }
        }

        public string VideoPath {
            get => tb_videoFilePath.Text;
            set {
                tb_videoFilePath.Text = value;
                cb_videoPathValid.BackColor = File.Exists(value) ? colGreen : colRed;
                videoPlayer?.SetSource(value);
            }
        }

        public ConfigSettings() {
            InitializeComponent();
            logger.SetLogBox(tb_logs);
            config.setConfig(Path.Combine(Environment.CurrentDirectory, "EurofighterCockpitConfig.json"));
        }

        private void ConfigSettings_Load(object sender, EventArgs e) {

            if (isConfigFileValid()) {
                tb_ip.Text = config.Dict["ipAddress"];
                tb_port.Text = config.Dict["port"];
                VideoPath = config.Dict["defaultVideoPath"];
            }
            else {
                MessageBox.Show("ERROR in config file!\nPlease check your json syntax");
                Environment.Exit(1);
            }

            mainSlides = new BaseSlide[] {
                new Slide2(),
                new Slide3(),
            };
            subSlides = new BaseSlide[] {
                new Slide1(),
            };

            initializeScreens();
            initializeWindows();
            initializeController();

            logger.LogToBox("...ready!");
        }

        private bool isConfigFileValid() {
            if (config.Dict != null &&
                config.Dict.ContainsKey("ipAddress") && 
                config.Dict.ContainsKey("port") &&
                config.Dict.ContainsKey("defaultVideoPath"))
                return true;
            return false;
        }

        private void initializeController() {
            controller = new CockpitController(config.Dict["ipAddress"], config.Dict["port"]);

            controller.JoystickDataUpdated += updateControllerDisplay;
            controller.PayloadUpdated += updateServoDisplay;
            controller.ConnectionStatusChanged += onConnectionStatusChanged;
            controller.JoystickConnectionChanged += updateJoystickState;
            controller.ThrottleConnectionChanged += updateThrottleState;

            controller.LogMessage += msg => logger.Log(msg);

            controller.Start();
        }


        #region ui update methods
        // ===============================================================

        private void updateServoDisplay(byte[] payload) {
            sd_canardLeft.Value = payload[1];
            sd_canardRight.Value = payload[2];
            sd_aileronLeft.Value = payload[3];
            sd_aileronRight.Value = payload[4];
            sd_flapLeft.Value = payload[5];
            sd_flapRight.Value = payload[6];
            sd_airbrake.Value = payload[7];
            sd_rudder.Value = payload[8];
        }

        private void updateControllerDisplay(JoystickData data) {
            bpb_joystickXpos.Progress = Convert.ToInt32(data.JoystickXPercent * 100);
            bpb_joystickXneg.Progress = Convert.ToInt32(data.JoystickXPercent * -100);
            bpb_joystickYpos.Progress = Convert.ToInt32(data.JoystickYPercent * 100);
            bpb_joystickYneg.Progress = Convert.ToInt32(data.JoystickYPercent * -100);
            bpb_joystickTorque.Progress = Convert.ToInt32(data.JoystickTorquePercent * 100);
            bpb_airbrake.Progress = data.Airbrake ? 100 : 0;
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

        private void onConnectionStatusChanged(bool connected) {
            // update info box ui according to pi connection status
            if (InvokeRequired) {
                Invoke(new Action(() => onConnectionStatusChanged(connected)));
                return;
            }
            cb_connectionState.Text = connected ? "CONNECTED" : "NOT CONNECTED";
            cb_connectionState.BackColor = connected ? colGreen : colRed;
        }

        private void updateJoystickState(bool connected) {
            if (InvokeRequired) {
                Invoke(new Action(() => updateJoystickState(connected)));
                return;
            }
            cb_joystickConnected.BackColor = connected ? colGreen : colRed;
        }

        private void updateThrottleState(bool connected) {
            if (InvokeRequired) {
                Invoke(new Action(() => updateThrottleState(connected)));
                return;
            }
            cb_throttleConnected.BackColor = connected ? colGreen : colRed;
        }

        private void updateServoDisplayLocks() {
            bool shouldBeLocked = !bt_overwriteControllerInput.IsChecked || bt_sleep.IsChecked ? false : true;
            foreach (var sd in p_forServoDisplays.Controls.OfType<ServoDisplay>()) {
                sd.isLocked(shouldBeLocked);
            }
        }

        // ===============================================================
        #endregion

        #region button events
        // ===============================================================

        private void bt_showNetworkTraffic_UserClick(object sender, EventArgs e) {
            controller.EnableNetworkLog(bt_showNetworkTraffic.IsChecked);
        }

        private void bt_overwriteControllerInput_UserClick(object sender, EventArgs e) {
            controller?.EnableOverwrite(bt_overwriteControllerInput.IsChecked);
            updateServoDisplayLocks();
        }

        private void bt_sleep_UserClick(object sender, EventArgs e) {
            controller.EnableSleepMode(bt_sleep.IsChecked);
            updateServoDisplayLocks();
        }

        private void btn_startServoTest_Click(object sender, EventArgs e) {
            controller.StartServoTest();
        }

        private void servoOverright_ValueChanged(object sender, EventArgs e) {
            if (!bt_overwriteControllerInput.IsChecked)
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
            payload[8] = sd_rudder.Value;
            // send to the pi
            controller.SendManualPayload(payload);
        }

        private void ConfigSettings_FormClosing(object sender, FormClosingEventArgs e) {
            controller?.Dispose();
        }

        // ===============================================================
        #endregion

        #region screen + window logic
        // ===============================================================

        private void initializeScreens() {
            screens = Screen.AllScreens;
            screenCount = screens.Length;
            screenIndicators = new ScreenIndicator[screenCount];
            for (int i = 0; i < screenCount; i++) {
                screenIndicators[i] = new ScreenIndicator(screens[i], i);
            }
        }

        private void initializeWindows() {
            videoPlayer = launchWindow(ref videoPlayer, videoPlayerScreenIndex, bt_videoPlayer, vp => {
                vp.SetSource(VideoPath);
            });
            infotainment = launchWindow(ref infotainment, infotainmentScreenIndex, bt_infotainment, i => {
                i.SetSlidePool(mainSlides);
                //i.ShowSlide(0);
            });
            infotainmentSub = launchWindow(ref infotainmentSub, infotainmentSubScreenIndex, bt_infotainmentSub, i => {
                i.HidePanel();
                i.SetSlidePool(subSlides);
                //i.ShowSlide(0);
            });
            populateScreenSelectors(tlp_videoPlayer, videoPlayer, screenCount);
            populateScreenSelectors(tlp_infotainment, infotainment, screenCount);
            populateScreenSelectors(tlp_infotainmentSub, infotainmentSub, screenCount);

            ShowMainSlide(0);
            ShowSubSlide(0);
        }

        private void toggleScreenIndicator() {
            if (ShowScreenIndicator)
                Array.ForEach(screenIndicators, i => i.Show());
            else
                Array.ForEach(screenIndicators, i => i.Hide());
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
            //logger.log($"{window.GetType().Name} launched!");
            return window;
        }

        private void moveWindowToScreen(Form form, int screenIndex) {
            if (form == null || screenIndex < 0 || screenIndex >= screens.Length)
                return;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = screens[screenIndex].WorkingArea.Location;
        }

        // ===============================================================
        #endregion


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
                rb.Cursor = Cursors.Hand;
                rb.Click += new EventHandler(anyScreenSelector_Click);
                // add radio button to parent and justify the width
                tly.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));
                tly.Controls.Add(rb, i, 0);
            }
            // select first one automatically
            ((RadioButton)tly.Controls[0]).Checked = true;
        }

        #region event handler
        private void bt_showSceenIndicators_UserClick(object sender, EventArgs e) {
            ShowScreenIndicator = bt_showSceenIndicators.IsChecked;
        }

        private void bt_videoPlayer_UserClick(object sender, EventArgs e) {
            if (videoPlayer == null)
                videoPlayer = launchWindow(ref videoPlayer, videoPlayerScreenIndex, bt_videoPlayer, vp => vp.SetSource(VideoPath));
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
                infotainmentSub = launchWindow(ref infotainmentSub, infotainmentSubScreenIndex, bt_infotainmentSub, inf => inf.HidePanel());
            else
                infotainmentSub.Close();
        }

        private void anyScreenSelector_Click(object sender, EventArgs e) {
            RadioButton rb = sender as RadioButton;
            int screenIndex = Convert.ToInt32(rb.Text);
            if (rb.Parent == tlp_videoPlayer) {
                videoPlayerScreenIndex = screenIndex;
                moveWindowToScreen(videoPlayer, screenIndex);
                videoPlayer?.Activate();  // bring to focus
            }
            if (rb.Parent == tlp_infotainment) {
                infotainmentScreenIndex = screenIndex;
                moveWindowToScreen(infotainment, infotainmentScreenIndex);
                infotainment?.Activate();  // bring to focus
            }
            if (rb.Parent == tlp_infotainmentSub) {
                infotainmentSubScreenIndex = screenIndex;
                moveWindowToScreen(infotainmentSub, infotainmentSubScreenIndex);
                infotainmentSub?.Activate();  // bring to focus
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
                controller?.ReinitializeDevices();
            }
            base.WndProc(ref m);
        }

        #endregion

        public void ShowMainSlide(int slideIndex) {
            // to prevent index out of range error
            if (slideIndex < 0 && slideIndex > mainSlides.Length)
                return;
            mainSlides[slideIndex].MainSlideRequested += (s, e) => {
                Console.WriteLine("you have been heard");
                ShowMainSlide(e.TargetSlide);
            };
            infotainment.ShowSlide(slideIndex);
        }

        public void ShowSubSlide(int slideIndex) {
            // to prevent index out of range error
            if (slideIndex < 0 && slideIndex > subSlides.Length)
                return;
            subSlides[slideIndex].SubSlideRequested += (s, e) => {
                ShowSubSlide(e.TargetSlide);
            };
            infotainmentSub.ShowSlide(slideIndex);
        }
    }
}
