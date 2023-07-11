using System;
using System.Collections.Generic;
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

    public ICommand SelectedDateChangedCommand { get; private set; }
    public ICommand GoToMatchDetailCommand { get; private set; }


    public CalendarPageViewModel(INavigationService navigationService, ISportsService sportsService)
    {
        Matches = sportsService.GetMatchesByDate(DateTime.Today);

        SelectedDateChangedCommand = new RelayCommand(parameter =>
        {
            Matches = sportsService.GetMatchesByDate((DateTime)parameter);
        });
        GoToMatchDetailCommand = new RelayCommand(parameter =>
        {
            if (parameter is not Match match)
                return;

            navigationService.GoTo(PageType.MatchDetailPage, new MatchDetailPageParameters(match));
        });
    }
}
