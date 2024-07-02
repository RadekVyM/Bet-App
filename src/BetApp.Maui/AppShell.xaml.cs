using BetApp.Core.Interfaces.Services;
using BetApp.Maui.Views.Pages;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using SimpleToolkit.SimpleShell.Extensions;
using SimpleToolkit.SimpleShell.Transitions;

namespace BetApp.Maui;

public partial class AppShell : SimpleShell
{
	public AppShell()
	{
		InitializeComponent();

        Loaded += AppShellLoaded;

        Routing.RegisterRoute(PageType.MatchDetailPage.ToString(), typeof(MatchDetailPage));

        this.SetTransition(
            callback: static args =>
            {
                switch (args.TransitionType)
                {
                    case SimpleShellTransitionType.Switching:
                        break;
                    case SimpleShellTransitionType.Pushing:
                        // Hide the page until it is fully measured
                        args.DestinationPage.Opacity = args.DestinationPage.Width < 0 ? 0.01 : 1;
                        // Slide the page in from right
                        args.DestinationPage.TranslationX = (1 - args.Progress) * args.DestinationPage.Width;
                        break;
                    case SimpleShellTransitionType.Popping:
                        // Slide the page out to right
                        args.OriginPage.TranslationX = args.Progress * args.OriginPage.Width;
                        break;
                }
            },
            finished: static args =>
            {
                args.OriginPage.Opacity = 1;
                args.OriginPage.TranslationX = 0;
                args.DestinationPage.Opacity = 1;
                args.DestinationPage.TranslationX = 0;
                if (args.OriginShellSectionContainer is not null)
                    args.OriginShellSectionContainer.Opacity = 1;
                if (args.DestinationShellSectionContainer is not null)
                    args.DestinationShellSectionContainer.Opacity = 1;
            },
            destinationPageInFront: static args => args.TransitionType switch
            {
                SimpleShellTransitionType.Popping => false,
                _ => true
            },
            duration: static args => args.TransitionType switch
            {
                SimpleShellTransitionType.Switching => 0u,
                _ => 200u
            },
            easing: static args => args.TransitionType switch
            {
                SimpleShellTransitionType.Pushing => Easing.SinIn,
                SimpleShellTransitionType.Popping => Easing.SinOut,
                _ => Easing.Linear
            });
    }

    private static void AppShellLoaded(object sender, EventArgs e)
    {
        var shell = sender as AppShell;

        shell.Window.SubscribeToSafeAreaChanges(safeArea =>
        {
            shell.tabBar.Margin = safeArea;
            shell.rootPageContainer.Padding = new Thickness(0, safeArea.Top, 0, 0);
        });
    }

    private async void ItemClicked(object sender, EventArgs e)
    {
        var button = sender as View;
        var shellItem = button.BindingContext as BaseShellItem;

        if (!CurrentState.Location.OriginalString.Contains(shellItem.Route))
            await this.GoToAsync($"///{shellItem.Route}", true);
    }
}

