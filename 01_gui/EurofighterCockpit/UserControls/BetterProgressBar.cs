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
    public enum Direction {
        leftToRight,
        rightToLeft,
        topToBottom,
        bottomToTop,
    }

    public partial class BetterProgressBar : UserControl
    {
        private int progress = 0;  // value from 0 to 100
        private Direction direction;

        public BetterProgressBar() {
            InitializeComponent();
        }

        public int Progress { 
            get => progress; 
            set {
                progress = Math.Min(100, Math.Max(0, value));  // crop value to desired range
                // update the UI
                if (direction == Direction.leftToRight || direction == Direction.rightToLeft)
                    p_progress.Width = Size.Width * value / 100;
                else
                    p_progress.Height = Size.Height * value / 100;
            } 
        }

        public Direction Direction { 
            get => direction;
            set {
                direction = value;
                if (value == Direction.leftToRight) p_progress.Dock = DockStyle.Left;
                else if (value == Direction.rightToLeft) p_progress.Dock = DockStyle.Right;
                else if (value == Direction.topToBottom) p_progress.Dock = DockStyle.Top;
                else if (value == Direction.bottomToTop) p_progress.Dock = DockStyle.Bottom;
            }
        }

        public Color ColorProg { get => p_progress.BackColor; set => p_progress.BackColor = value; }
    }
}
