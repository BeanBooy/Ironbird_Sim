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
    public partial class Slide3 : BaseSlide
    {
        public Slide3() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            RequestMainSlide(0);
        }
    }
}
