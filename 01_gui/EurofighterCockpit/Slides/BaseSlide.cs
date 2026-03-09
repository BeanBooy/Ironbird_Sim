using System;
using System.Windows.Forms;

namespace EurofighterCockpit.Slides
{
    public class BaseSlide : UserControl
    {
        public event EventHandler<SlideNavigationEventArgs> MainSlideRequested;
        public event EventHandler<SlideNavigationEventArgs> SubSlideRequested;
        public event EventHandler<EventArgs> MovieRequested;

        public void RequestMainSlide(string targetSlideName) {
            MainSlideRequested?.Invoke(this, new SlideNavigationEventArgs(targetSlideName));
        }

        public void RequestSubSlide(string targetSlideName) {
            SubSlideRequested?.Invoke(this, new SlideNavigationEventArgs(targetSlideName));
        }

        public void RequestMovie() {
            MovieRequested?.Invoke(this, new EventArgs());
        }

        public virtual void OnShow() { }
    }
}
