using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace BetApp.Core
{
    public class MatchesPageViewModel : BasePageViewModel, IMatchesPageViewModel
    {
        IEnumerable<Sport> sportMatches;
        string selectedSport;
        private IEnumerable<string> allSportNames;

        public IEnumerable<string> AllSportNames
        {
            get => allSportNames;
            set
            {
                allSportNames = value;
                OnPropertyChanged(nameof(AllSportNames));
            }
        }
        public IEnumerable<Sport> SportMatches
        {
            get => sportMatches;
            set
            {
                sportMatches = value;
                OnPropertyChanged(nameof(SportMatches));
            }
        }
        public string SelectedSport
        {
            get => selectedSport;
            set
            {
                selectedSport = value;
                OnPropertyChanged(nameof(SelectedSport));
            }
        }

        public ICommand SportSelectedCommand { get; private set; }
        public ICommand GoToMatchDetailCommand { get; private set; }

        public MatchesPageViewModel(INavigationService navigationService, ISportsService sportsService)
        {
            SportMatches = sportsService.GetAllSports().ToList();
            AllSportNames = SportMatches.Select(s => s.Name).ToList();

            SportSelectedCommand = new RelayCommand(parameter =>
            {
                SelectedSport = parameter != null ? parameter.ToString() : null;

                if (SelectedSport == null)
                    SportMatches = sportsService.GetAllSports();
                else
                    SportMatches = sportsService.GetSport(SelectedSport);
            });
            GoToMatchDetailCommand = new RelayCommand(parameter => navigationService.Push(PagesEnum.MatchDetailPage, parameter));
        }
    }
}
