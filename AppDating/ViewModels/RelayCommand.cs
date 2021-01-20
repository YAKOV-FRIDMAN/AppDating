using System;
using System.Collections.Generic;
using System.Text;
 
using System.Windows.Input;

namespace AppDating.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
    
        public RelayCommand(Action<object> execute)
        {
            _execute = execute;

        }

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null ? true : _canExecute(parameter);
            }
            catch { return true; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
         
    }
}
