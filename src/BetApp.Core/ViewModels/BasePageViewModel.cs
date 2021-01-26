using System.ComponentModel;

namespace BetApp.Core
{
    public class BasePageViewModel : INotifyPropertyChanged, IBasePageViewModel
    {
        public virtual void OnPagePushing(params object[] parameters) { }

        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
