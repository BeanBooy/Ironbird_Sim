using AxWMPLib;
using System;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class VideoPlayer : Form
    {
        private bool isMoviePlaying;
        private string defaultMediaPath = null;

        public VideoPlayer() {
            InitializeComponent();
            // hide media player ui
            windowsMediaPlayer.uiMode = "none";
            // enable endless video loop
            windowsMediaPlayer.settings.setMode("loop", true);
        }

        public void SetDefaultSource(string mediaPath) {
            windowsMediaPlayer.URL = mediaPath;
            defaultMediaPath = mediaPath;
            // for whatever reason the sound setting are lost when setting a new url
            // that's why they have to be set again
            windowsMediaPlayer.settings.mute = true;
            windowsMediaPlayer.Ctlcontrols.play();
        }

        public void SetSource(string mediaPath) {
            windowsMediaPlayer.URL = mediaPath;
            // for whatever reason the sound setting are lost when setting a new url
            // that's why they have to be set again
            windowsMediaPlayer.settings.mute = true;
            windowsMediaPlayer.Ctlcontrols.play();
        }

        public void StartMovie(string moviePath) {
            isMoviePlaying = true;
            windowsMediaPlayer.settings.setMode("loop", false);
            SetSource(moviePath);
        }

        private void windowsMediaPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e) {
            if (isMoviePlaying && (WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded) {
                isMoviePlaying = false;
                // defer execution until WMP finished its internal transition
                BeginInvoke((Action)(() => {
                    windowsMediaPlayer.settings.setMode("loop", true);
                    SetSource(defaultMediaPath);
                }));
            }
        }
    }
}
