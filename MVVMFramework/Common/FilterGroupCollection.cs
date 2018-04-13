using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFramework.Common
{
    /// <summary>
    /// A filtered group collection
    /// </summary>
    /// <typeparam name="T">Collection value type</typeparam>
    public class FilterGroupCollection<T> : IFilterCollection<T>
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
        /// The grouping function
        /// </summary>
        private Func<T, int> grouping;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterGroupCollection{T}"/> class
        /// </summary>
        /// <param name="defaultView">The default view</param>
        public FilterGroupCollection(List<T> defaultView)
        {
            this.defaultView = defaultView;
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
        /// Gets the filtered group list
        /// </summary>
        public ObservableCollection<IGrouping<int, T>> FilteredList { get; private set; } = new ObservableCollection<IGrouping<int, T>>();

        /// <summary>
        /// Gets or sets the grouping function
        /// </summary>
        public Func<T, int> Grouping
        {
            get
            {
                return this.grouping;
            }

            set
            {
                this.grouping = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Refresh the default View by filter and grouping
        /// </summary>
        public void Refresh()
        {
            if (this.Grouping != null)
            {
                IEnumerable<IGrouping<int, T>> result;

                this.FilteredList.Clear();

                if (this.Filter != null)
                {
                    result = this.defaultView.Where(this.Filter).GroupBy(this.Grouping);
                }
                else
                {
                    result = this.defaultView.GroupBy(this.Grouping);
                }

                foreach (var entry in result)
                {
                    this.FilteredList.Add(entry);
                }
            }
            else
            {
                throw new Exception("Missing grouping for filterGroupCollection");
            }
        }
    }
}
