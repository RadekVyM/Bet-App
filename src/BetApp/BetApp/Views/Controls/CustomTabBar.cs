using Xamarin.Forms;

namespace BetApp
{
    public class CustomTabBar : TabBar
    {
        public TabBarView TabBarView { get; private set; }

        public CustomTabBar()
        {
            TabBarView = new TabBarView();

            TabBarView.HeightRequest = 80;
        }
    }
}
