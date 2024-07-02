using System.Windows.Input;
using BetApp.Core.Interfaces.Services;
using BetApp.Core.Interfaces.ViewModels;
using BetApp.Core.Models;

namespace BetApp.Core.ViewModels;

public class MatchDetailPageViewModel : BasePageViewModel, IMatchDetailPageViewModel
{
    private Match? match;

    public Match? Match
    {
        get => match;
        set
        {
            match = value;
            OnPropertyChanged(nameof(Match));
        }
    }

    public ICommand GoBackCommand { get; private set; }


    public MatchDetailPageViewModel(INavigationService navigationService)
    {
        GoBackCommand = new RelayCommand(() => navigationService.GoBack());
    }


    public override void OnApplyFirstParameters(IParameters parameters)
    {
        base.OnApplyFirstParameters(parameters);

        if (parameters is not MatchDetailPageParameters matchDetailParameters)
            return;

        Match = matchDetailParameters.Match;
    }
}
