using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Maui.Views.Pages;

public partial class CupPage : BaseRootContentPage
{
    public CupPage(INavigationService navigationService) : base(navigationService)
    {
        InitializeComponent();
    }
}
