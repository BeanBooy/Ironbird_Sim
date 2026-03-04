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
    public partial class SlideMovie : BaseSlide
    {
        public SlideMovie() {
            InitializeComponent();
        }

        private void btn_launchMovie_Click(object sender, EventArgs e) {
            RequestMovie();
        }
    }
}
