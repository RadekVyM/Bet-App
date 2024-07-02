using System.Collections.Generic;
using System.Windows.Input;
using BetApp.Core.Models;

namespace BetApp.Core.Interfaces.ViewModels;

public interface ICalendarPageViewModel : IBasePageViewModel
{
    IEnumerable<Match> Matches { get; set; }
    ICommand SelectedDateChangedCommand { get; }
}