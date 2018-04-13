using System;
using System.Windows.Input;

namespace MVVMFramework.Framework
{
    /// <summary>
    /// Command with parameter
    /// </summary>
    /// <typeparam name="T">Event argument type of the Command</typeparam>
    public class CommandWithParams<T> : ICommand
    {
        /// <summary>
        /// The action
        /// </summary>
        private Action<T> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandWithParams{T}"/> class
        /// </summary>
        /// <param name="action">The command action</param>
        public CommandWithParams(Action<T> action)
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
            var castParameter = (T)Convert.ChangeType(parameter, typeof(T));
            this.action(castParameter);
        }
    }
}
