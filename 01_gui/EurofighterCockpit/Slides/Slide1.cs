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
    public partial class Slide1 : UserControl
    {
        private Dictionary<Control, Rectangle> originalBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private Size originalSize;
        private bool initialized = false;

        public Size OriginalSize { get => originalSize; }

        public Slide1() {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.None;
        }

        public void InitializeScaling() {
            if (initialized) return;

            originalSize = this.Size;

            foreach (Control c in GetAllControls(this)) {
                c.Dock = DockStyle.None;
                c.Anchor = AnchorStyles.None;

                originalBounds[c] = c.Bounds;
                originalFontSizes[c] = c.Font.Size;
            }

            initialized = true;
        }

        public void ApplyScale(float scale) {
            if (!initialized) return;

            foreach (Control c in GetAllControls(this)) {
                Rectangle r = originalBounds[c];

                c.Bounds = new Rectangle(
                    (int)(r.X * scale),
                    (int)(r.Y * scale),
                    (int)(r.Width * scale),
                    (int)(r.Height * scale)
                );

                float newFontSize = originalFontSizes[c] * scale;
                c.Font = new Font(c.Font.FontFamily, newFontSize, c.Font.Style);
            }

            Size = new Size(
                (int)(originalSize.Width * scale),
                (int)(originalSize.Height * scale)
            );
        }

        private IEnumerable<Control> GetAllControls(Control parent) {
            foreach (Control c in parent.Controls) {
                yield return c;

                foreach (var child in GetAllControls(c))
                    yield return child;
            }
        }

    }
}
