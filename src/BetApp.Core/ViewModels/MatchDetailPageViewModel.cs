using System.Windows.Input;

namespace BetApp.Core
{
    public class MatchDetailPageViewModel : BasePageViewModel, IMatchDetailPageViewModel
    {
        private Match match;

        public Match Match
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
            GoBackCommand = new RelayCommand(() => navigationService.Pop());
        }


        public override void OnPagePushing(params object[] parameters)
        {
            if (parameters != null && parameters.Length != 0)
                Match = parameters[0] as Match;
        }
    }
}
