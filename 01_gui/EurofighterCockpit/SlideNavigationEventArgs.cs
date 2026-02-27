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
        public int TargetSlide { get; }

        public SlideNavigationEventArgs(int targetSlide) {
            TargetSlide = targetSlide;
        }
    }
}
