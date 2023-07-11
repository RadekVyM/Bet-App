using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BetApp.Avalonia.Services;
using BetApp.Avalonia.ViewModels;
using BetApp.Avalonia.Views;
using BetApp.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BetApp.Avalonia;

public partial class App : Application
{
    private readonly ServiceProvider serviceProvider;


    public App()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ShellView>();
        services.AddTransient<CalendarPage>();
        services.AddTransient<CupPage>();
        services.AddTransient<FavoritesPage>();
        services.AddTransient<MatchesPage>();
        services.AddTransient<MatchPage>();
        services.AddTransient<MainWindow>();

        services.AddSingleton<NavigationService>();
        services.AddSingleton<INavigationService>(s => s.GetRequiredService<NavigationService>());
        services.AddSingleton<ISportsService, SportsService>();

        services.AddTransient<IMatchesPageViewModel, MatchesPageViewModel>();
        services.AddTransient<ICalendarPageViewModel, CalendarPageViewModel>();
        services.AddTransient<IMatchDetailPageViewModel, MatchDetailPageViewModel>();

        serviceProvider = services.BuildServiceProvider();
    }


    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = serviceProvider.GetRequiredService<MainWindow>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = serviceProvider.GetRequiredService<ShellView>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}