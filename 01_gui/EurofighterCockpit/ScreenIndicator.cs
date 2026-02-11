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
    public partial class ScreenIndicator : Form
    {
        public ScreenIndicator(int number)
        {
            InitializeComponent();

            screenNumber.Text = number.ToString();

        }
    }
}
