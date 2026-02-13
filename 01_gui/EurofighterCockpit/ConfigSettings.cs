using System;
using System.Collections;
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
        private Screen[] screens;
        private bool showScreenIndicator;
        private ScreenIndicator[] screenIndicators;

        public ConfigSettings() {
            InitializeComponent();

            screens = Screen.AllScreens;
            showScreenIndicator = false;
            screenIndicators = new ScreenIndicator[screens.Length];
            for (int i = 0; i < screens.Length; i++) {
                screenIndicators[i] = new ScreenIndicator(Screen.AllScreens[i], i);
            }
        }

        public bool ShowScreenIndicator { 
            get { return showScreenIndicator; } 
            set { 
                showScreenIndicator = value;
                toggleScreenIndicator();
            }
        }

        private void screenIndicator_CheckedChanged(object sender, EventArgs e) {
            this.ShowScreenIndicator = screenIndicator.Checked;
        }

        private void toggleScreenIndicator() {
            if (ShowScreenIndicator) {
                Array.ForEach(screenIndicators, obj => obj.Show());
            }
            else {
                Array.ForEach(screenIndicators, obj => obj.Hide());
            }
        }

    }
}
