using MVVMFramework.ViewProperties;
using System.Threading.Tasks;

namespace MVVMFramework.ViewModel
{
    /// <summary>
    /// Interface for the view Model base with properties
    /// </summary>
    /// <typeparam name="T">The view property type</typeparam>
    public interface IViewModelBase<T> : IViewModelBase where T : ViewPropertyBase, new()
    {
        /// <summary>
        /// Gets the properties
        /// </summary>
        T Properties { get; }
    }

    /// <summary>
    /// Interface for the view Model base
    /// </summary>
    public interface IViewModelBase
    {
        /// <summary>
        /// Initializes the object
        /// </summary>
        /// <param name="obj">The object parameter</param>
        /// <returns>Async task</returns>
        Task Init(object obj = null);
    }
}
