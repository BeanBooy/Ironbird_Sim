namespace EurofighterCockpit.Slides
{
    public partial class SlideEurofighter : BaseSlide
    {
        public SlideEurofighter() {
            InitializeComponent();
        }

        public override void OnShow() {
            RequestSubSlide("eurofighter");
        }
    }
}
