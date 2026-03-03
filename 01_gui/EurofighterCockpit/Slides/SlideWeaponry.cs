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
            RequestSubSlide(0);
        }

        private void btn_Taurus_Click(object sender, EventArgs e) {
            RequestSubSlide(1);
        }

        private void btn_Paveway_Click(object sender, EventArgs e) {
            RequestSubSlide(2);
        }
    }
}
