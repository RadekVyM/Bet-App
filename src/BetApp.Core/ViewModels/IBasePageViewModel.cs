using System.ComponentModel;

namespace BetApp.Core
{
    public interface IBasePageViewModel : INotifyPropertyChanged
    {
        void OnPagePushing(params object[] parameters);
        void OnPropertyChanged(string property);
    }
}
