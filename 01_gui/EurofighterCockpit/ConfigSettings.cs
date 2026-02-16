using EurofighterCockpit.Slides;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class ConfigSettings : Form
    {
        public Color colRed = Color.FromName("Crimson");
        public Color colGreen = Color.FromArgb(40, 209, 43);

        private Logger logger;

        private Screen[] screens;
        private int screenCount;
        private bool showScreenIndicator;
        private ScreenIndicator[] screenIndicators;

        private VideoPlayer videoPlayer;
        private string videoPath;

        private Infotainment infotainment;
        private Infotainment infotainmentSub;

        public ConfigSettings() {
            InitializeComponent();

            screens = Screen.AllScreens;
            screenCount = screens.Length;
            showScreenIndicator = false;
            screenIndicators = new ScreenIndicator[screenCount];
            for (int i = 0; i < screenCount; i++) {
                screenIndicators[i] = new ScreenIndicator(screens[i], i);
            }

            logger = new Logger();



            videoPlayer = launchVideoPlayer();
            infotainment = launchInfotainment();
            infotainmentSub = launchInfotainmentSub();

            populateScreenSelectors(tlp_videoPlayer, screenCount);
            populateScreenSelectors(tlp_infotainment, screenCount);
            populateScreenSelectors(tlp_infotainmentSub, screenCount);

            displayMessage("...ready!");

            // testing section !!!!!!!!!!!

            infotainment.ShowSlide(new Slide1());
        }

        public bool ShowScreenIndicator { 
            get { return showScreenIndicator; } 
            set { 
                showScreenIndicator = value;
                toggleScreenIndicator();
            }
        }
        public string VideoPath {
            get { return videoPath; } 
            set {
                videoPath = value;
                tb_videoFilePath.Text = value;
                tb_videoFilePath.BackColor = File.Exists(value) ? Color.FromName("Control") : colRed;
                videoPlayer?.setSource(value);
            }
        }

        private VideoPlayer launchVideoPlayer() {
            videoPlayer = new VideoPlayer();
            videoPlayer.Load += (_, __) => { toggleBtn(btn_videoPlayer, true); };
            videoPlayer.FormClosed += (_, __) => { toggleBtn(btn_videoPlayer, false); videoPlayer = null; };
            // default video path (start automaticlly without user input)
            VideoPath = "E:\\Dev\\Ironbird_Sim\\demoVid.mp4";
            videoPlayer.Show();
            displayMessage($"video player launched ({VideoPath})");
            logger.log($"video player launched ({VideoPath})");
            return videoPlayer;
        }

        private Infotainment launchInfotainment() {
            infotainment = new Infotainment();
            infotainment.Load += (_, __) => { toggleBtn(btn_infotainment, true); };
            infotainment.FormClosed += (_, __) => { toggleBtn(btn_infotainment, false); infotainment = null; };
            infotainment.Show();
            displayMessage("infotainment launched");
            logger.log("infotainment launched");
            return infotainment;
        }

        private Infotainment launchInfotainmentSub() {
            infotainmentSub = new Infotainment();
            infotainmentSub.Load += (_, __) => { toggleBtn(btn_infotainmentSub, true); };
            infotainmentSub.FormClosed += (_, __) => { toggleBtn(btn_infotainmentSub, false); infotainmentSub = null; };
            infotainmentSub.hidePanel();
            infotainmentSub.Show();
            displayMessage("infotainmentSub launched");
            logger.log("infotainmentSub launched");
            return infotainmentSub;
        }

        private void toggleBtn(Button btn, bool state) {
            btn.BackColor = state ? colGreen : colRed;
            btn.Text = state ? "ON" : "OFF";
        }

        private void screenIndicator_CheckedChanged(object sender, EventArgs e) {
            ShowScreenIndicator = screenIndicator.Checked;
        }

        private void toggleScreenIndicator() {
            if (ShowScreenIndicator) {
                Array.ForEach(screenIndicators, obj => obj.Show());
            }
            else {
                Array.ForEach(screenIndicators, obj => obj.Hide());
            }
        }

        private void btn_browseVideoFile_MouseClick(object sender, MouseEventArgs e) {
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

        //private void btn_videoPlayerScreenToggle_Click(object sender, EventArgs e) {
        //    if (videoPlayer == null) {
        //        // video play is off and should be turned on
        //        videoPlayer = launchVideoPlayer();
        //    }
        //    else {
        //        // video play is on and should be turned off
        //        videoPlayer.Close();
        //        videoPlayer = null;
        //    }
        //}

        private void anyWindowToggle_Click(object sender, EventArgs e) {
            if (sender == btn_videoPlayer) {
                if (videoPlayer == null) {
                    videoPlayer = launchVideoPlayer();
                }
                else {
                    videoPlayer.Close();
                    videoPlayer = null;
                }
            }
            if (sender == btn_infotainment) {
                if (infotainment == null) {
                    infotainment = launchInfotainment();
                }
                else {
                    infotainment.Close();
                    infotainment = null;
                }
            }
            if (sender == btn_infotainmentSub) {
                if (infotainmentSub == null) {
                    infotainmentSub = launchInfotainmentSub();
                }
                else {
                    infotainmentSub.Close();
                    infotainmentSub = null;
                }
            }
        }

        private void populateScreenSelectors(TableLayoutPanel tly, int columns) {
            // should be 3 screens/culumns for perfect setup,
            // but why hardcode it if a dynamic complicated solution is possible ;)
            tly.Controls.Clear();
            tly.RowStyles.Clear();
            tly.ColumnStyles.Clear();
            tly.RowCount = 1;
            tly.ColumnCount = columns;
            // make row fill entire height (I think it's default tbh)
            tly.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            // create columns
            for (int i = 0; i < columns; i++) {
                // each column gets equal width
                tly.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                RadioButton rb = new RadioButton();
                rb.Text = i.ToString();
                rb.Dock = DockStyle.Fill;
                rb.TextAlign = ContentAlignment.MiddleCenter;
                rb.Appearance = Appearance.Button;
                rb.BackColor = Color.FromName("Control");
                rb.FlatStyle = FlatStyle.Flat;
                rb.FlatAppearance.CheckedBackColor = Color.Orange;

                tly.Controls.Add(rb, i, 0);
            }
        }

        private void displayMessage(string message) {
            try {
                if (!message.EndsWith(Environment.NewLine)) {
                    message += Environment.NewLine;
                }

                string formatedMessage = $"[{DateTime.Now.ToString("HH:mm:ss")}] {message}";
                tb_logs.AppendText(formatedMessage);

                // scroll to last line if needed
                tb_logs.ScrollToCaret();
            }
            catch (Exception ex) {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                string severity = ex.GetType().Name;
                logger.log($"{methodName}: {severity} - {ex.ToString()}");
            }
        }
    }
}
