using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private Screen[] screens;
        private bool showScreenIndicator;
        private ScreenIndicator[] screenIndicators;

        private VideoPlayer videoPlayer = new VideoPlayer();
        private string videoPath;

        public ConfigSettings() {
            InitializeComponent();

            screens = Screen.AllScreens;
            showScreenIndicator = false;
            screenIndicators = new ScreenIndicator[screens.Length];
            for (int i = 0; i < screens.Length; i++) {
                screenIndicators[i] = new ScreenIndicator(Screen.AllScreens[i], i);
            }




            videoPlayer = launchVideoPlayer();
            // ...
            // ...

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
                tb_videoFilePath.BackColor = File.Exists(value) ? Color.FromName("Control") : Color.Crimson;
                videoPlayer?.setSource(value);
            }
        }

        private VideoPlayer launchVideoPlayer() {
            videoPlayer = new VideoPlayer();
            //videoPlayer.FormClosed += new FormClosedEventHandler(func_name);
            videoPlayer.FormClosed += (sender, e) => {
                p_videoPlayerStatus.BackColor = Color.FromName("Crimson");
                videoPlayer = null;
            };

            VideoPath = "E:\\Dev\\Ironbird_Sim\\demoVid.mp4";  // default video path (start automaticlly without user input)
            videoPlayer.Show();
            p_videoPlayerStatus.BackColor = Color.FromName("Green");
            return videoPlayer;
        }

        private void screenIndicator_CheckedChanged(object sender, EventArgs e) {
            this.ShowScreenIndicator = screenIndicator.Checked;
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

        private void btn_videoPlayerScreenReset_Click(object sender, EventArgs e) {
            // close window if not done already
            if (videoPlayer != null) {
                videoPlayer.Close();
                videoPlayer = null;
            }
            // start again
            videoPlayer = launchVideoPlayer();
        }
    }
}
