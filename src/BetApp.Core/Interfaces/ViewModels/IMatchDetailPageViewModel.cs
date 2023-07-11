using System.Windows.Input;
using BetApp.Core.Models;

namespace BetApp.Core.Interfaces.ViewModels;

public interface IMatchDetailPageViewModel : IBasePageViewModel
{
    ICommand GoBackCommand { get; }
    Match? Match { get; set; }
}