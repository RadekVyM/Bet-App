using BetApp.Core;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            tabBar.Items.Add(new ShellContent { Route = PagesEnum.MatchesPage.ToString(), ContentTemplate = new DataTemplate(typeof(MatchesPage)) });
            tabBar.Items.Add(new ShellContent { Route = PagesEnum.CalendarPage.ToString(), ContentTemplate = new DataTemplate(typeof(CalendarPage)) });
            tabBar.Items.Add(new ShellContent { Route = PagesEnum.FavoritesPage.ToString(), ContentTemplate = new DataTemplate(typeof(FavoritesPage)) });
            tabBar.Items.Add(new ShellContent { Route = PagesEnum.CupPage.ToString(), ContentTemplate = new DataTemplate(typeof(CupPage)) });

            Routing.RegisterRoute(PagesEnum.MatchDetailPage.ToString(), typeof(MatchDetailPage));
        }

        protected override async void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            await UpdateTabBarVisibility();
        }

        public async Task<bool> UpdateTabBarVisibility()
        {
            var page = Shell.Current.GetCurrentPage();

            bool isHidden = page == PagesEnum.MatchDetailPage;

            CustomTabBar tabBar = Items.FirstOrDefault() as CustomTabBar;

            if (isHidden)
                await tabBar?.TabBarView.HideTabBarAsync();
            else
                await tabBar?.TabBarView.ShowTabBarAsync();

            return isHidden;
        }
    }
}