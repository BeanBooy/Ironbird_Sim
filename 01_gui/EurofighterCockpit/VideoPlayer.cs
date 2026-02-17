using AxWMPLib;
using EurofighterCockpit.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public void setSource(string mediaPath) {
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
