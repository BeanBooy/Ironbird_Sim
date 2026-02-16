using EurofighterCockpit.Slides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class Infotainment : Form
    {
        public Infotainment() {
            InitializeComponent();
        }

        public void hidePanel() {
            flowLayoutPanel1.Width = 0;
            p_content.Dock = DockStyle.Fill;
        }

        private Slide1 currentSlide;


        public void ShowSlide(Slide1 slide) {
            p_content.Controls.Clear();
            currentSlide = slide;

            p_content.Controls.Add(slide);

            slide.InitializeScaling();

            ResizeSlide();
        }

        private void ResizeSlide() {
            if (currentSlide == null) return;

            Size baseSize = currentSlide.OriginalSize;

            float scaleX = (float)p_content.ClientSize.Width / baseSize.Width;
            float scaleY = (float)p_content.ClientSize.Height / baseSize.Height;
            float scale = Math.Min(scaleX, scaleY);

            currentSlide.ApplyScale(scale);

            currentSlide.Location = new Point(
                (p_content.ClientSize.Width - currentSlide.Width) / 2,
                (p_content.ClientSize.Height - currentSlide.Height) / 2
            );
        }


    }
}
