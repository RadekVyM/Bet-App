using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace BetApp.Core
{
    public class CalendarPageViewModel : BasePageViewModel, ICalendarPageViewModel
    {
        private IEnumerable<Match> matches;

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
            GoToMatchDetailCommand = new RelayCommand(parameter => navigationService.Push(PagesEnum.MatchDetailPage, parameter));
        }
    }
}
