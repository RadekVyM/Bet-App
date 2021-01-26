using System.Collections.Generic;
using System.Windows.Input;

namespace BetApp.Core
{
    public interface IMatchesPageViewModel
    {
        IEnumerable<string> AllSportNames { get; set; }
        ICommand GoToMatchDetailCommand { get; }
        string SelectedSport { get; set; }
        IEnumerable<Sport> SportMatches { get; set; }
        ICommand SportSelectedCommand { get; }
    }
}