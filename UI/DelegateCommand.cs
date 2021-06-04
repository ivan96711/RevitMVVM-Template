using System;
using System.Windows.Input;

namespace RevitMVVM.UI
{
    public class DelegateCommand<T> : ICommand
    {
        #region Private fields

        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        #endregion

        #region Constructors

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region DelegateCommand

        public void Execute(T parameter)
        {
            var handler = _execute;
            if (handler != null)
            {
                handler(parameter);
            }
        }

        public bool CanExecute(T parameter)
        {
            var handler = _canExecute;
            return handler == null || handler(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region ICommand

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T)parameter);
        }

        #endregion
    }

    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
            : base(execute, canExecute)
        {
        }
    }

    public class ActionCommand : DelegateCommand<object>, ICommand
    {
        #region Private fields

        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        #endregion

        #region Constructors

        public ActionCommand(Action action, Func<bool> canExecute = null)
            : base(null, null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        #endregion

        #region ActionCommand

        public void Execute()
        {
            var handler = _action;
            if (handler != null)
            {
                handler();
            }
        }

        public bool CanExecute()
        {
            var handler = _canExecute;
            return handler == null || handler();
        }

        #endregion

        #region ICommand

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        #endregion
    }
}
