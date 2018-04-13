using System;
using System.Windows.Input;

namespace MVVMFramework.Framework
{
    /// <summary>
    /// Class for Command Binding
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// The action
        /// </summary>
        private Action action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class
        /// </summary>
        /// <param name="action">The action to be executed</param>
        public Command(Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// Event for changes of CanExecute
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Checks if the Command can be executed
        /// </summary>
        /// <param name="parameter">Is not used</param>
        /// <returns>Always true</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execution of the action
        /// </summary>
        /// <param name="parameter">Is not used</param>
        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
