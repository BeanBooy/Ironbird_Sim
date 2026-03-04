using System;
using System.Windows.Forms;

namespace EurofighterCockpit.Slides
{
    public class BaseSlide : UserControl
    {
        public event EventHandler<SlideNavigationEventArgs> MainSlideRequested;
        public event EventHandler<SlideNavigationEventArgs> SubSlideRequested;
        public event EventHandler<EventArgs> MovieRequested;

        public void RequestMainSlide(int targetSlide) {
            MainSlideRequested?.Invoke(this, new SlideNavigationEventArgs(targetSlide));
        }

        public void RequestSubSlide(int targetSlide) {
            SubSlideRequested?.Invoke(this, new SlideNavigationEventArgs(targetSlide));
        }

        public void RequestMovie() {
            MovieRequested?.Invoke(this, new EventArgs());
        }
    }
}
