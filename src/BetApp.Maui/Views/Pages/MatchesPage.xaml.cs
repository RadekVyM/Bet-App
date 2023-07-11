using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Maui.Views.Pages;

public partial class MatchesPage : BaseRootContentPage
{
	public MatchesPage(INavigationService navigationService, IMatchesPageViewModel viewModel) : base(navigationService)
	{
		BindingContext = viewModel;

        InitializeComponent();
	}

    protected override void OnSafeAreaChanged(Thickness safeArea)
    {
        base.OnSafeAreaChanged(safeArea);

        collectionViewFooter.HeightRequest = safeArea.Bottom + 80;
    }
}
