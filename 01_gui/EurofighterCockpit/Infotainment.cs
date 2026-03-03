using EurofighterCockpit.Slides;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class Infotainment : Form
    {
        // slides
        private BaseSlide[] slides = null;
        private int currentSlideIndex = -1;

        private Color highlightCol = Color.FromArgb(0, 32, 91);

        public Infotainment() {
            InitializeComponent();
        }

        public void SetSlidePool(BaseSlide[] slides) {
            this.slides = slides;
        }

        public void HidePanel() {
            p_SlideSelector.Width = 0;
            p_content.Dock = DockStyle.Fill;
        }

        public void ShowSlide(int slideIndex) {
            if (currentSlideIndex == slideIndex)
                return;
            currentSlideIndex = slideIndex;
            // to prevent index out of range error
            if (slideIndex < 0 || slideIndex >= slides.Length)
                return;
            p_content.Controls.Clear();
            p_content.Controls.Add(slides[slideIndex]);
        }

        private void ResetAllButtons() {
            foreach (var button in p_SlideSelector.Controls.OfType<Button>()) {
                button.BackColor = Color.Black;
            }
        }

        private void btn_Click(object sender, EventArgs e) {
            ResetAllButtons();
            ((Button)sender).BackColor = highlightCol;
            if (sender == btn_Eurofighter) ShowSlide(0);
            else if (sender == btn_Systems) ShowSlide(1);
            else if (sender == btn_Weaponry) ShowSlide(2);
            else if (sender == btn_Engine) ShowSlide(3);
            else if (sender == btn_Joystick) ShowSlide(4);
            else if (sender == btn_Movie) ShowSlide(5);
        }

    }
}
