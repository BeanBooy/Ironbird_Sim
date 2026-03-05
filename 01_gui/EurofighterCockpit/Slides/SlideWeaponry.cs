using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            RequestSubSlide(1);
        }

        private void btn_Taurus_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(0);
        }

        private void btn_Paveway_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(2);
        }

        private void btn_Sidewinder_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(3);
        }
        private void btn_Meteor_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(4);
        }

        private void btn_RECCE_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(5);
        }

        private void btn_Laser_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(6);
        }

        private void btn_Iris_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(7);
        }

        private void btn_Harm_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(8);
        }

        private void btn_Amraam_Click(object sender, EventArgs e) {
            SelectedButton = (Button)sender;
            RequestSubSlide(9);
        }
    }
}
