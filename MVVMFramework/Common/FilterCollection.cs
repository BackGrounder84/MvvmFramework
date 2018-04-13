using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFramework.Common
{
    /// <summary>
    /// A filtered collection
    /// </summary>
    /// <typeparam name="T">Collection type</typeparam>
    public class FilterCollection<T> : IFilterCollection<T>
    {
        /// <summary>
        /// The default view
        /// </summary>
        private List<T> defaultView;

        /// <summary>
        /// The filter function
        /// </summary>
        private Func<T, bool> filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterCollection{T}"/> class
        /// </summary>
        /// <param name="defaultView">The default view</param>
        public FilterCollection(List<T> defaultView)
        {
            this.DefaultView = defaultView;
        }

        /// <summary>
        /// Gets or sets the default view
        /// </summary>
        public List<T> DefaultView
        {
            get
            {
                return this.defaultView;
            }

            set
            {
                this.defaultView = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the filter function
        /// </summary>
        public Func<T, bool> Filter
        {
            get
            {
                return this.filter;
            }

            set
            {
                this.filter = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets the filtered list
        /// </summary>
        public ObservableCollection<T> FilteredList { get; private set; } = new ObservableCollection<T>();

        /// <summary>
        /// Refresh the default View by filter
        /// </summary>
        public void Refresh()
        {
            this.FilteredList.Clear();

            IEnumerable<T> result;
            if (this.Filter != null)
            {
                result = this.DefaultView.Where(this.Filter);
            }
            else
            {
                result = this.DefaultView;
            }

            foreach (var item in result)
            {
                this.FilteredList.Add(item);
            }
        }
    }
}
