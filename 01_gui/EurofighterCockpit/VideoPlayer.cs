using LibVLCSharp.Shared;
using System;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class VideoPlayer : Form
    {
        private LibVLC libVLC;
        private MediaPlayer mediaPlayer;
        private Media defaultMedia;
        private bool isMoviePlaying;

        public VideoPlayer() {
            InitializeComponent();
            Core.Initialize();
            libVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(libVLC);
            videoView.MediaPlayer = mediaPlayer;
            mediaPlayer.EndReached += MediaPlayer_EndReached;
            mediaPlayer.Mute = true;
        }

        public void SetDefaultSource(string mediaPath) {
            defaultMedia = new Media(libVLC, mediaPath, FromType.FromPath);
            mediaPlayer.Play(defaultMedia);
        }

        public void StartMovie(string moviePath) {
            isMoviePlaying = true;
            var media = new Media(libVLC, moviePath, FromType.FromPath);
            mediaPlayer.Mute = false;
            mediaPlayer.Play(media);
        }

        private void MediaPlayer_EndReached(object sender, EventArgs e) {
            if (IsDisposed || !IsHandleCreated)
                return;
            if (isMoviePlaying) {
                isMoviePlaying = false;
                mediaPlayer.Mute = true;
            }
            // restart default video
            BeginInvoke(new Action(() => {
                mediaPlayer.Play(defaultMedia);
            }));
        }
    }
}
