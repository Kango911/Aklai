using System;
using System.Windows.Input;

namespace Aklai.Extra;

public class CommandDelegate : ICommand
{
    private Action<object> _execute;
    private Func<object, bool> _canExecute;

    public CommandDelegate(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
        => _canExecute == null || _canExecute(parameter);


    public void Execute(object? parameter)
        => _execute?.Invoke(parameter);

    public event EventHandler? CanExecuteChanged;
}