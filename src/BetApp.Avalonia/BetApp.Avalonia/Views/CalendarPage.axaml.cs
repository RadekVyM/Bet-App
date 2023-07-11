using Avalonia.Controls;
using BetApp.Core;

namespace BetApp.Avalonia.Views;

public partial class CalendarPage : UserControl
{
    private readonly ICalendarPageViewModel? viewModel;

    public CalendarPage()
    {
        InitializeComponent();
    }

    public CalendarPage(ICalendarPageViewModel viewModel) : this()
    {
        DataContext = this.viewModel = viewModel;
    }
}