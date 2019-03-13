using System;
using System.Windows.Input;

namespace ZeroApp.ForecastTracker.Client.Commands
{
    public class EnterCommand : ICommand
    {
        private readonly Action _action;
        public EnterCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}