using System.Collections.Generic;
using System.Windows.Input;

namespace BetApp.Core
{
    public interface ICalendarPageViewModel
    {
        IEnumerable<Match> Matches { get; set; }
        ICommand SelectedDateChangedCommand { get; }
    }
}