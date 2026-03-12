using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EurofighterCockpit.Slides
{
    public partial class SlideWeaponry : BaseSlide
    {
        private Button selectedButton = null;
        private Color selectedColor = Color.FromArgb(200, 0, 0, 0);
        private Color defaultColor;

        public Button SelectedButton {
            get => selectedButton;
            set {
                selectedButton = value;
                foreach (var button in Controls.OfType<Button>())
                    button.BackColor = defaultColor;
                value.BackColor = selectedColor;
            }
        }

        public SlideWeaponry() {
            InitializeComponent();
            defaultColor = btn_Iris.BackColor;
        }

        public override void OnShow() {
            btn_Tank_Click(btn_Tank, null);
        }

        private void btn_Tank_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("1000LiterTank");
        }

        private void btn_Taurus_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("taurus");
        }

        private void btn_Paveway_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("paveway2");
        }

        private void btn_Sidewinder_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("aim9Sidewinder");
        }
        private void btn_Meteor_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("meteor");
        }

        private void btn_RECCE_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("recce");
        }

        private void btn_Laser_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("laserPod");
        }

        private void btn_Iris_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("irisT");
        }

        private void btn_Harm_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("agm88harm");
        }

        private void btn_Amraam_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide("aim120amraam");
        }
    }
}
