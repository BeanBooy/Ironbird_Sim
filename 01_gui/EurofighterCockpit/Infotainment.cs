using EurofighterCockpit.Slides;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class Infotainment : Form
    {
        // slides
        //private BaseSlide[] slides = null;
        private Dictionary<string, BaseSlide> slides = null;
        //private int currentSlideIndex = -1;
        private string currentSlideName = String.Empty;

        private Color highlightCol = Color.FromArgb(0, 32, 91);

        public Infotainment() {
            InitializeComponent();
        }

        public void SetSlidePool(Dictionary<string, BaseSlide> slides) {
            this.slides = slides;
        }

        public void HidePanel() {
            p_SlideSelector.Width = 0;
            p_content.Dock = DockStyle.Fill;
        }

        public void ShowSlide(string slideName) {
            if (currentSlideName == slideName)
                return;
            if (slides.ContainsKey(slideName)) {
                // load selected slide onto panel
                currentSlideName = slideName;
                p_content.Controls.Clear();
                p_content.Controls.Add(slides[slideName]);
                slides[slideName].OnShow();
            }

        }

        private void ResetAllButtons() {
            foreach (var button in p_SlideSelector.Controls.OfType<Button>()) {
                button.BackColor = Color.Black;
            }
        }

        private void btn_Click(object sender, EventArgs e) {
            ResetAllButtons();
            ((Button)sender).BackColor = highlightCol;
            if (sender == btn_Eurofighter) ShowSlide("eurofighter");
            else if (sender == btn_Systems) ShowSlide("systems");
            else if (sender == btn_Weaponry) ShowSlide("weaponry");
            else if (sender == btn_Engine) ShowSlide("engine");
            else if (sender == btn_Joystick) ShowSlide("joystick");
            else if (sender == btn_Movie) ShowSlide("movie");
        }

    }
}
