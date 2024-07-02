using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;
using BetApp.Core.Services;
using BetApp.Core.ViewModels;
using BetApp.Maui.Services;
using BetApp.Maui.Views.Pages;
using Microsoft.Extensions.Logging;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace BetApp.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                fonts.AddFont("OpenSans-ExtraBold.ttf", "OpenSansExtraBold");
            });

        builder.UseSimpleShell();
        builder.UseSimpleToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

#if IOS || ANDROID
        builder.DisplayContentBehindBars();
#endif
#if ANDROID
        builder.SetDefaultStatusBarAppearance(Colors.Transparent, true);
#endif

        builder.Services.AddTransient<AppShell>();

        builder.Services.AddTransient<MatchesPage>();
        builder.Services.AddTransient<CalendarPage>();
        builder.Services.AddTransient<CupPage>();
        builder.Services.AddTransient<FavoritesPage>();
        builder.Services.AddTransient<MatchDetailPage>();

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<ISportsService, SportsService>();

        builder.Services.AddTransient<IMatchesPageViewModel, MatchesPageViewModel>();
        builder.Services.AddTransient<IMatchDetailPageViewModel, MatchDetailPageViewModel>();
        builder.Services.AddTransient<ICalendarPageViewModel, CalendarPageViewModel>();

        return builder.Build();
    }
}