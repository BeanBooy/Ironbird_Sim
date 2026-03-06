using EurofighterCockpit.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurofighterCockpit
{
    public class SlideNavigationEventArgs : EventArgs
    {
        public string TargetSlide { get; }

        public SlideNavigationEventArgs(string targetSlide) {
            TargetSlide = targetSlide;
        }
    }
}
