using System;

namespace EurofighterCockpit.Slides
{
    public partial class SlideSystems : BaseSlide
    {
        public SlideSystems() {
            InitializeComponent();
        }

        public override void OnShow() {
            button20_Click(button20, null);
        }

        private void button9_Click(object sender, EventArgs e) {
            RequestSubSlide("imrs");
        }

        private void button15_Click(object sender, EventArgs e) {
            RequestSubSlide("dc");
        }

        private void button14_Click(object sender, EventArgs e) {
            RequestSubSlide("nav");
        }

        private void button13_Click(object sender, EventArgs e) {
            RequestSubSlide("acs");
        }

        private void button12_Click(object sender, EventArgs e) {
            RequestSubSlide("dass");
        }

        private void button11_Click(object sender, EventArgs e) {
            RequestSubSlide("ai");
        }

        private void button10_Click(object sender, EventArgs e) {
            RequestSubSlide("comms");
        }
        private void button3_Click(object sender, EventArgs e) {
            RequestSubSlide("structure");
        }

        private void button1_Click(object sender, EventArgs e) {
            RequestSubSlide("jettisonCes");
        }

        private void button2_Click(object sender, EventArgs e) {
            RequestSubSlide("engines");
        }

        private void button7_Click(object sender, EventArgs e) {
            RequestSubSlide("fcs");
        }

        private void button4_Click(object sender, EventArgs e) {
            RequestSubSlide("ess");
        }

        private void button5_Click(object sender, EventArgs e) {
            RequestSubSlide("mss");
        }

        private void button6_Click(object sender, EventArgs e) {
            RequestSubSlide("glu");
        }

        private void button8_Click(object sender, EventArgs e) {
            RequestSubSlide("landingGear");
        }

        private void button18_Click(object sender, EventArgs e) {
            RequestSubSlide("electric");
        }

        private void button21_Click(object sender, EventArgs e) {
            RequestSubSlide("ecslss");
        }

        private void button17_Click(object sender, EventArgs e) {
            RequestSubSlide("fuel");
        }

        private void button16_Click(object sender, EventArgs e) {
            RequestSubSlide("hydraulic");
        }

        private void button19_Click(object sender, EventArgs e) {
            RequestSubSlide("sps");
        }

        private void button20_Click(object sender, EventArgs e) {
            RequestSubSlide("avionicSystems");
        }

        private void button22_Click(object sender, EventArgs e) {
            RequestSubSlide("generalSystems");
        }

        private void button23_Click(object sender, EventArgs e) {
            RequestSubSlide("gss");
        }
    }
}
