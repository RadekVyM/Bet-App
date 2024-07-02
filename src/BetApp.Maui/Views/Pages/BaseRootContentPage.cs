using BetApp.Core.Interfaces.Services;

namespace BetApp.Maui.Views.Pages;

public class BaseRootContentPage : BaseContentPage
{
    public BaseRootContentPage(INavigationService navigationService) : base(navigationService)
    {
    }

    protected override void OnSafeAreaChanged(Thickness safeArea)
    {
    }
}