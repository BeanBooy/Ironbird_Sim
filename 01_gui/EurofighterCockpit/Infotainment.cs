using EurofighterCockpit.Slides;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class Infotainment : Form
    {
        // slides
        private BaseSlide[] slides = null;

        public Infotainment() {
            InitializeComponent();
        }

        public void SetSlidePool(BaseSlide[] slides) {
            this.slides = slides;
        }

        public void HidePanel() {
            panel1.Width = 0;
            p_content.Dock = DockStyle.Fill;
        }

        public void ShowSlide(int slideIndex) {
            // to prevent index out of range error
            if (slideIndex < 0 && slideIndex > slides.Length)
                return; 
            //slides[slideIndex].SlideRequested += (s, e) => {
            //    ShowSlide(e.TargetSlide);
            //};
            p_content.Controls.Clear();
            p_content.Controls.Add(slides[slideIndex]);
        }

        private void button1_Click(object sender, EventArgs e) {
            ShowSlide(0);

        }

        private void button2_Click(object sender, EventArgs e) {
            ShowSlide(1);
        }
    }
}
