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
    public partial class SlideEngine : BaseSlide
    {
        public SlideEngine() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RequestSubSlide(33);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RequestSubSlide(34);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RequestSubSlide(35);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RequestSubSlide(36);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            RequestSubSlide(37);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestSubSlide(38);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestSubSlide(39);
        }
    }
}
