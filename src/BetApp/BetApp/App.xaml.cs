using BetApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace BetApp
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "Shapes_Experimental", "Brush_Experimental" });

            var services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ISportsService, SportsService>();
            services.AddTransient<IMatchesPageViewModel, MatchesPageViewModel>();
            services.AddTransient<ICalendarPageViewModel, CalendarPageViewModel>();
            services.AddTransient<IMatchDetailPageViewModel, MatchDetailPageViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
