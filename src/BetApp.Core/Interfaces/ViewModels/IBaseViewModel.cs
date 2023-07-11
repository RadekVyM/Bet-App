using System.ComponentModel;

namespace BetApp.Core.Interfaces.ViewModels;

public interface IBaseViewModel : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}
