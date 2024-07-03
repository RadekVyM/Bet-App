using BetApp.Core.Interfaces.Services;
using BetApp.Maui.Views.Pages;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace BetApp.Maui;

public partial class AppShell : SimpleShell
{
	public AppShell()
	{
		InitializeComponent();

        Loaded += AppShellLoaded;

        Routing.RegisterRoute(PageType.MatchDetailPage.ToString(), typeof(MatchDetailPage));
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
            await Shell.Current.GoToAsync($"///{shellItem.Route}", true);
    }
}