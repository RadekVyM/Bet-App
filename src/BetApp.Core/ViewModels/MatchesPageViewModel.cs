using System.Windows.Input;
using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;
using BetApp.Core.Models;

namespace BetApp.Core.ViewModels;

public class MatchesPageViewModel : BasePageViewModel, IMatchesPageViewModel
{
    private string? selectedSport;
    private IEnumerable<Sport> sportMatches = [];
    private IEnumerable<string> allSportNames = [];

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

    public ICommand SportSelectedCommand { get; private init; }
    public ICommand GoToMatchDetailCommand { get; private init; }


    public MatchesPageViewModel(INavigationService navigationService, ISportsService sportsService)
    {
        SportMatches = sportsService.GetAllSports().ToList();
        AllSportNames = SportMatches.Select(s => s.Name).ToList();

        SportSelectedCommand = new RelayCommand(parameter =>
        {
            SelectedSport = parameter?.ToString();
            SportMatches = parameter is null ?
                sportsService.GetAllSports().ToList() :
                sportsService.GetSport(SelectedSport ?? "").ToList();
        });
        GoToMatchDetailCommand = new RelayCommand(parameter =>
        {
            if (parameter is not Match match)
                return;

            navigationService.GoTo(PageType.MatchDetailPage, new MatchDetailPageParameters(match));
        });
    }
}