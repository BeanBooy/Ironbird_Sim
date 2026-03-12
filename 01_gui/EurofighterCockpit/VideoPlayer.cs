using System;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class VideoPlayer : Form
    {
        public VideoPlayer() {
            InitializeComponent();
            // hide media player ui
            windowsMediaPlayer.uiMode = "none";
            // enable endless video loop
            windowsMediaPlayer.settings.setMode("loop", true);
        }

        public void SetSource(string mediaPath) {
            windowsMediaPlayer.URL = mediaPath;
            // for whatever reason the sound setting are lost when setting a new url
            // that's why they have to be set again
            windowsMediaPlayer.settings.mute = true;
        }

        private void VideoPlayer_LocationChanged(object sender, EventArgs e) {
            Console.WriteLine("Location Changed");
            //windowsMediaPlayer.Ctlcontrols.play();
        }

        private void VideoPlayer_Move(object sender, EventArgs e) {
            Console.WriteLine("Move");
            //windowsMediaPlayer.Ctlcontrols.pause();
        }
    }
}
