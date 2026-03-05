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
    public partial class SlideJoystick : BaseSlide
    {
        private static SlideJoystick instance = null;

        public SlideJoystick() {
            InitializeComponent();
            instance = this;
        }

        public static SlideJoystick GetInstance() {
            // instance required to set controller input updates
            return instance;
        }

        public void DisplayControllerInput(JoystickData data) {
            bpb_joystickXpos.Progress = Convert.ToInt32(data.JoystickXPercent * 100);
            bpb_joystickXneg.Progress = Convert.ToInt32(data.JoystickXPercent * -100);
            bpb_joystickYpos.Progress = Convert.ToInt32(data.JoystickYPercent * 100);
            bpb_joystickYneg.Progress = Convert.ToInt32(data.JoystickYPercent * -100);
            bpb_joystickTorque.Progress = Convert.ToInt32(data.JoystickTorquePercent * 100);
            bpb_airbrake.Progress = data.Airbrake ? 100 : 0;
            bpb_throttle.Progress = Convert.ToInt32(data.ThrottlePercent * 100);
            bpb_trigger.Progress = data.Trigger ? 100 : 0;
            bpb_rudderL.Progress = data.RudderLeft ? 100 : 0;
            bpb_rudderR.Progress = data.RudderRight ? 100 : 0;
            bpb_rudderReset.Progress = data.RudderReset ? 100 : 0;
            bpb_gear.Progress = data.LandingGear ? 100 : 0;
            bpb_positionLights.Progress = data.PositionalLights ? 100 : 0;
            bpb_landingLights.Progress = data.LandingLights ? 100 : 0;
        }
    }
}
