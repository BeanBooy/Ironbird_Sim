using System;

namespace EurofighterCockpit.Slides
{
    public partial class SlideMovie : BaseSlide
    {
        public SlideMovie() {
            InitializeComponent();
        }

        public override void OnShow() {
            //RequestSubSlide("joystick");  // will override main joystick slide
        }

        private void btn_launchMovie_Click(object sender, EventArgs e) {
            RequestMovie();
        }
    }
}
