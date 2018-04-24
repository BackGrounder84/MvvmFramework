#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using MVVMFramework.ViewProperties;
using System.Threading.Tasks;

namespace MVVMFramework.ViewModel
{
    /// <summary>
    /// Base class for a view model
    /// </summary>
    /// <typeparam name="T">Type of the property class</typeparam>
    public abstract class ViewModelBase<T> : ViewModelBase, IViewModelBase<T> where T : ViewPropertyBase, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase{Property}"/> class
        /// </summary>
        protected ViewModelBase()
        {
            this.Properties = new T();
        }

        /// <inheritdoc/>
        public T Properties { get; private set; }
    }

    /// <summary>
    /// Base class for a view model
    /// </summary>
    public abstract class ViewModelBase : IViewModelBase
    {
        /// <inheritdoc/>
        public virtual void Init(object obj = null)
        {
        }

        /// <inheritdoc/>
        public async virtual Task InitAsync(object obj = null)
        {
        }
    }
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore SA1402 // File may only contain a single type
