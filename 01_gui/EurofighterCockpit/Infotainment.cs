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

        private Color highlightCol = Color.FromArgb(0, 32, 91);

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
            if (slideIndex < 0 || slideIndex >= slides.Length)
                return; 
            p_content.Controls.Clear();
            p_content.Controls.Add(slides[slideIndex]);
        }

        private void ResetAllButtons() {
            btn_Eurofighter.BackColor = Color.Black;
            btn_Systems.BackColor = Color.Black;
            btn_Weaponry.BackColor = Color.Black;
            btn_Joystick.BackColor = Color.Black;
            btn_Movie.BackColor = Color.Black;
        }

        private void btn_Click(object sender, EventArgs e) {
            ResetAllButtons();
            ((Button)sender).BackColor = highlightCol;
            if (sender == btn_Eurofighter) ShowSlide(2);
            else if (sender == btn_Systems) ShowSlide(3);
            else if (sender == btn_Weaponry) ShowSlide(4);
            else if (sender == btn_Joystick) ShowSlide(5);
            else if (sender == btn_Movie) ShowSlide(6);
        }

    }
}
