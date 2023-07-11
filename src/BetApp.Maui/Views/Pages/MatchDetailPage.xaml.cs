using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;
using BetApp.Maui.Extensions;
using BetApp.Maui.Views.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace BetApp.Maui.Views.Pages;

public partial class MatchDetailPage : BaseContentPage
{
    public const string FirtsTabText = "MARKET";
    public const string SecondTabText = "MATCHED BET";
    public const string ThirdTabText = "UNMATCHED";

    private object selectedTab;

    public object SelectedTab
    {
        get => selectedTab;
        set
        {
            selectedTab = value;
            OnPropertyChanged(nameof(SelectedTab));
        }
    }


    public MatchDetailPage(INavigationService navigationService, IMatchDetailPageViewModel viewModel) : base(navigationService)
    {
        BindingContext = viewModel;

        InitializeComponent();

        TabTapped(firstTabItem, EventArgs.Empty);
    }


    protected override void OnSafeAreaChanged(Thickness safeArea)
    {
        Padding = new Thickness(safeArea.Left, safeArea.Top, safeArea.Right, 0);
    }

    private void TabTapped(object sender, EventArgs e)
    {
        var view = sender as TabItem;

        SelectedTab = view.BindingContext;

        scrollView.Content = view.BindingContext.ToString() switch
        {
            FirtsTabText => scrollView.Content = Resources.GetValue<DataTemplate>("FirstTabContentDataTemplate").CreateContent() as View,
            SecondTabText => scrollView.Content = Resources.GetValue<DataTemplate>("SecondTabContentDataTemplate").CreateContent() as View,
            ThirdTabText => scrollView.Content = Resources.GetValue<DataTemplate>("ThirdTabContentDataTemplate").CreateContent() as View,
            _ => null
        };
    }
}
