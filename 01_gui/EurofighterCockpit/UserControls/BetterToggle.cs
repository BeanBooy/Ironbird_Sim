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
    public partial class BetterToggle : UserControl
    {
        private bool isChecked;
        private bool isHovered;

        private Color colOn = Color.FromArgb(132, 189, 0);
        private Color colOff = Color.FromArgb(228, 0, 43);
        private Color col_hover = Color.FromArgb(40, Color.Black);

        public event EventHandler UserClick;

        protected virtual void OnUserClick(EventArgs e) {
            UserClick?.Invoke(this, e);
        }

        public BetterToggle() {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            Cursor = Cursors.Hand;

        }

        public bool IsChecked {
            get => isChecked;
            set {
                if (isChecked == value) return;
                isChecked = value;
                Invalidate();
                Update();
            }
        }

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            isHovered = false;
            Invalidate();
        }

        protected override void OnClick(EventArgs e) {
            base.OnClick(e);
            IsChecked = !IsChecked;
            OnUserClick(EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            // background
            Color trackColor = isChecked ? colOn : colOff;
            using (Brush b = new SolidBrush(trackColor))
                g.FillRectangle(b, ClientRectangle);
            // knob
            int knobSize = Height - 3 - 3;
            int knobX = isChecked ? Width - knobSize - 3 : 3;
            using (Brush b = new SolidBrush(Color.White))
                g.FillRectangle(b, knobX, 3, knobSize, knobSize);
            // hover overlay
            if (isHovered) {
                using (Brush b = new SolidBrush(col_hover))
                    g.FillRectangle(b, ClientRectangle);
            }
        }


    }
}
