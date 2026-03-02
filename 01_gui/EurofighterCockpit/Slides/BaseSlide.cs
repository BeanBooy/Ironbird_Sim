using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EurofighterCockpit.Slides
{
    public class BaseSlide : UserControl
    {
        public event EventHandler<SlideNavigationEventArgs> MainSlideRequested;
        public event EventHandler<SlideNavigationEventArgs> SubSlideRequested;

        public void RequestMainSlide(int targetSlide) {
            MainSlideRequested?.Invoke(this, new SlideNavigationEventArgs(targetSlide));
        }

        public void RequestSubSlide(int targetSlide) {
            SubSlideRequested?.Invoke(this, new SlideNavigationEventArgs(targetSlide));
        }
    }
}
