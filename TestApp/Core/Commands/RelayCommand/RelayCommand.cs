using System;
using System.Windows.Input;

namespace TestApp.Core.Commands.RelayCommand {
    public class RelayCommand : ICommand {
        public RelayCommand(Action action, Func<bool> canExecute = null) {
            action_ = action;
            canExecute_ = canExecute;
        }

        public bool CanExecute(object parameter) =>
            canExecute_?.Invoke() ?? true;

        public void Execute(object parameter) =>
            action_?.Invoke();

        public event EventHandler CanExecuteChanged = (sender, args) => { };

        protected Action action_;
        protected Func<bool> canExecute_;
    }
}
