using AxWMPLib;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace EurofighterCockpit
{
    public partial class VLCPlayer : Form
    {
        private LibVLC libVLC;
        private MediaPlayer mediaPlayer;

        private bool isMoviePlaying;
        private string defaultMediaPath = null;

        public VLCPlayer() {
            InitializeComponent();
            Core.Initialize();
            libVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(libVLC);
            videoView.MediaPlayer = mediaPlayer;
            //mediaPlayer.EndReached += MediaPlayer_EndReached;
            mediaPlayer.Mute = true;
        }

        public void SetDefaultSource(string mediaPath) {
            var media = new Media(libVLC, mediaPath, FromType.FromPath);
            media.AddOption(":input-repeat=-1");
            mediaPlayer.Play(media);
            defaultMediaPath = mediaPath;
        }

        public void SetSource(string mediaPath) {
            var media = new Media(libVLC, mediaPath, FromType.FromPath);
            mediaPlayer.Play(media);
        }

        public void StartMovie(string moviePath) {
            isMoviePlaying = true;
            SetSource(moviePath);
        }

        //private void MediaPlayer_EndReached(object sender, EventArgs e) {
        //    Console.WriteLine("end reached!!");
        //    if (isMoviePlaying) {
        //    }
        //    else {
        //        Console.WriteLine("start default video...");
        //        this.Invoke(new Action(() => {
        //            var media = new Media(libVLC, defaultMediaPath, FromType.FromPath);
        //            mediaPlayer.Play(media);
        //        }));
        //    }
        //    //this.Invoke(new Action(() => {
        //    //    var media = new Media(libVLC, defaultMediaPath, FromType.FromPath);
        //    //    mediaPlayer.Play(media);
        //    //}));
        //}
    }
}
