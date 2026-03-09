using System;

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
