using System.Windows.Input;

namespace BetApp.Core;

public class RelayCommand : ICommand
{
    private readonly Action<object?>? parametredAction;
    private readonly Action? action;
    private readonly Predicate<object?>? canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action action, Predicate<object?>? canExecute)
    {
        this.action = action;
        this.canExecute = canExecute;
    }

    public RelayCommand(Action<object?> parametredAction, Predicate<object?>? canExecute)
    {
        this.parametredAction = parametredAction;
        this.canExecute = canExecute;
    }

    public RelayCommand(Action action) : this(action, null) { }

    public RelayCommand(Action<object?> parametredAction) : this(parametredAction, null) { }

    public bool CanExecute(object? parameter) =>
        canExecute is null || canExecute(parameter);

    public void Execute(object? parameter)
    {
        parametredAction?.Invoke(parameter);
        action?.Invoke();
    }

    public void OnCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}