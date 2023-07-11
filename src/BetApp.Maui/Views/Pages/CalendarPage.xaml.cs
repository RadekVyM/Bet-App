using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Maui.Views.Pages;

public partial class CalendarPage : BaseRootContentPage
{
    public CalendarPage(INavigationService navigationService, ICalendarPageViewModel viewModel) : base(navigationService)
    {
        BindingContext = viewModel;

        InitializeComponent();
    }
}
