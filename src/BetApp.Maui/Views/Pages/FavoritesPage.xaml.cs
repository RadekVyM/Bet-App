using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Maui.Views.Pages;

public partial class FavoritesPage : BaseRootContentPage
{
    public FavoritesPage(INavigationService navigationService) : base(navigationService)
    {
        InitializeComponent();
    }
}
