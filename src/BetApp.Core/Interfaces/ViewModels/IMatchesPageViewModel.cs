using System.Collections.Generic;
using System.Windows.Input;
using BetApp.Core.Models;

namespace BetApp.Core.Interfaces.ViewModels;

public interface IMatchesPageViewModel : IBasePageViewModel
{
    IEnumerable<string> AllSportNames { get; set; }
    IEnumerable<Sport> SportMatches { get; set; }
    string? SelectedSport { get; set; }
    ICommand GoToMatchDetailCommand { get; }
    ICommand SportSelectedCommand { get; }
}