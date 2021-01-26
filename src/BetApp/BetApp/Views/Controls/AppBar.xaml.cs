using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppBar : ContentView
    {
        public string BetLogoImage { get; set; }
        public string AvatarImage { get; set; }

        public AppBar()
        {
            BetLogoImage = "betlogo.png";
            AvatarImage = "logo.jpg";

            InitializeComponent();
        }
    }
}