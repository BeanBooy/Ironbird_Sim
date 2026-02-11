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
    public partial class ConfigSettings : Form
    {
        public ConfigSettings()
        {
            InitializeComponent();
        }

        private void ConfigSettings_Load(object sender, EventArgs e)
        {
            int screencount = Screen.AllScreens.Count();
            Console.WriteLine("screencount = " + screencount);

            for (int i = 0; i < screencount; i++) {
                ScreenIndicator si = new ScreenIndicator(i);
                si.Show();
                si.Location = new Point(Screen.AllScreens[i].Bounds.Left, Screen.AllScreens[i].Bounds.Top);
            }

            //this.Location = new Point(screen.Bounds.Left, screen.Bounds.Top);

            //Form fs = new FullscreenWrapper();
            //fs.Show();
        } 
    }
}
