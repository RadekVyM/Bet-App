using System.ComponentModel;
using BetApp.Core.Interfaces.ViewModels;

namespace BetApp.Core.ViewModels;

public abstract class BaseViewModel : IBaseViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}