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
        public SlideWeaponry() {
            InitializeComponent();
        }

        private void SlideWeaponry_Load(object sender, EventArgs e) {

        }

        private void btn_Tank_Click(object sender, EventArgs e) {
            RequestSubSlide(1);
        }

        private void btn_Taurus_Click(object sender, EventArgs e) {
            RequestSubSlide(0);
        }

        private void btn_Paveway_Click(object sender, EventArgs e) {
            RequestSubSlide(2);
        }


        private void btn_Sidewinder_Click(object sender, EventArgs e)
        {
            RequestSubSlide(3);
        }
        private void btn_Meteor_Click(object sender, EventArgs e)
        {
            RequestSubSlide(4);
        }

        private void btn_RECCE_Click(object sender, EventArgs e)
        {
            RequestSubSlide(5);
        }

        private void btn_Laser_Click(object sender, EventArgs e)
        {
            RequestSubSlide(6);
        }
    }
}
