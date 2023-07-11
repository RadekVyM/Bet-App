using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Maui.Views.Pages;

public partial class MatchDetailPage : BaseContentPage
{
    public MatchDetailPage(INavigationService navigationService, IMatchDetailPageViewModel viewModel) : base(navigationService)
    {
        BindingContext = viewModel;

        InitializeComponent();
    }
}
