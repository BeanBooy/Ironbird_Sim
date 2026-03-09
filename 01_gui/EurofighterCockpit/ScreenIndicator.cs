using System.Drawing;
using System.Windows.Forms;

namespace EurofighterCockpit
{
    public partial class ScreenIndicator : Form
    {
        public ScreenIndicator(Screen screen, int number) {
            InitializeComponent();
            // set lable content and position
            screenNumber.Text = number.ToString();
            Location = new Point(screen.Bounds.Left, screen.Bounds.Top);
        }
    }
}
