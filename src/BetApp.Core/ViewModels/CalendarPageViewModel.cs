using System.Windows.Input;
using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;
using BetApp.Core.Models;

namespace BetApp.Core.ViewModels;

public class CalendarPageViewModel : BasePageViewModel, ICalendarPageViewModel
{
    private IEnumerable<Match> matches = new List<Match>();

    public IEnumerable<Match> Matches
    {
        get => matches;
        set
        {
            matches = value;
            OnPropertyChanged(nameof(Matches));
        }
    }

    public ICommand SelectedDateChangedCommand { get; private init; }
    public ICommand GoToMatchDetailCommand { get; private init; }


    public CalendarPageViewModel(INavigationService navigationService, ISportsService sportsService)
    {
        Matches = sportsService.GetMatchesByDate(DateTime.Today);

        SelectedDateChangedCommand = new RelayCommand(parameter =>
        {
            if (parameter is DateTime dateTimeParameter)
                Matches = sportsService.GetMatchesByDate(dateTimeParameter);
        });
        GoToMatchDetailCommand = new RelayCommand(parameter =>
        {
            if (parameter is not Match match)
                return;

            navigationService.GoTo(PageType.MatchDetailPage, new MatchDetailPageParameters(match));
        });
    }
}