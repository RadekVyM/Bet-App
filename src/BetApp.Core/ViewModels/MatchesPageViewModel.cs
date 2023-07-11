using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;
using BetApp.Core.Models;

namespace BetApp.Core.ViewModels;

public class MatchesPageViewModel : BasePageViewModel, IMatchesPageViewModel
{
    private string? selectedSport;
    private IEnumerable<Sport> sportMatches = new List<Sport>();
    private IEnumerable<string> allSportNames = new List<string>();

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
    public string? SelectedSport
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
            SelectedSport = parameter?.ToString() ?? "";
            SportMatches = SelectedSport is null ?
                sportsService.GetAllSports() :
                sportsService.GetSport(SelectedSport);
        });
        GoToMatchDetailCommand = new RelayCommand(parameter =>
        {
            if (parameter is not Match match)
                return;

            navigationService.GoTo(PageType.MatchDetailPage, new MatchDetailPageParameters(match));
        });
    }
}
