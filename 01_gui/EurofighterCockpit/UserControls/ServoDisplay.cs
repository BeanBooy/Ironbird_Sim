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
    public partial class ServoDisplay : UserControl
    {
        private int min = 0;
        private int max = 255;
        public event EventHandler ValueChanged;

        public int Min {
            get => min;
            set { 
                trackBar.Minimum = value;
                min = value;
            } 
        }
        public int Max {
            get => max;
            set {
                trackBar.Maximum = value;
                max = value;
            }
        }

        public byte Value {
            get => Convert.ToByte(trackBar.Value);
            set {
                trackBar.Value = value;
                tb_bin.Text = Convert.ToString(value, 2).PadLeft(8, '0');
                tb_dec.Text = value.ToString();
            }
        }

        public ServoDisplay() {
            InitializeComponent();
        }

        private void trackBar_Scroll(object sender, EventArgs e) {
            tb_bin.Text = Convert.ToString(Value, 2).PadLeft(8, '0');
            tb_dec.Text = Value.ToString();
            // fire event if subscriber exists
            ValueChanged?.Invoke(this, e);
        }

        public void isLocked(bool locked) {
            trackBar.Enabled = locked;
        }

    }
}
