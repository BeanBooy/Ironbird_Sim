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
    public partial class Slide2 : BaseSlide
    {
        public Slide2() {
            InitializeComponent();
            Console.WriteLine("slide2 loaded");
        }

        private void button1_Click(object sender, EventArgs e) {
            Console.WriteLine("btn clicked");
        }

        private void button2_Click(object sender, EventArgs e) {
            RequestMainSlide(1);
        }

        private void button3_Click(object sender, EventArgs e) {
            Console.WriteLine("movie started");
        }
    }
}
