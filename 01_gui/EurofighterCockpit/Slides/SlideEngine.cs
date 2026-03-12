using System;

namespace EurofighterCockpit.Slides
{
    public partial class SlideEngine : BaseSlide
    {
        public SlideEngine() {
            InitializeComponent();
        }

        public override void OnShow() {
            RequestSubSlide("engines");
        }

        private void button1_Click(object sender, EventArgs e) {
            RequestSubSlide("hdCompressor");
        }

        private void button3_Click(object sender, EventArgs e) {
            RequestSubSlide("hdTurbine");
        }

        private void button5_Click(object sender, EventArgs e) {
            RequestSubSlide("afterburner");
        }

        private void button6_Click(object sender, EventArgs e) {
            RequestSubSlide("thruster");
        }

        private void button15_Click(object sender, EventArgs e) {
            RequestSubSlide("ndCompressor");
        }

        private void button2_Click(object sender, EventArgs e) {
            RequestSubSlide("burningChamber");
        }

        private void button4_Click(object sender, EventArgs e) {
            RequestSubSlide("ndTurbine");
        }
    }
}
