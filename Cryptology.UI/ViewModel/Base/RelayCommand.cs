using System;
using System.Windows.Input;

namespace Cryptology.UI.ViewModel.Base
{
    internal class RelayCommand : ICommand
    {
        private Action action = null;

        private Action<object> parametrizedAction = null;

        public RelayCommand(Action<object> action)
        {
            this.parametrizedAction = action;
        }

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (this.action is null)
            {
                this.parametrizedAction(parameter);
            }
            else
            {
                this.action();
            }
        }
    }
}
