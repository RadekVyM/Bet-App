using System.Windows.Input;

namespace BetApp.Core
{
    public interface IMatchDetailPageViewModel
    {
        ICommand GoBackCommand { get; }
        Match Match { get; set; }

        void OnPagePushing(params object[] parameters);
    }
}