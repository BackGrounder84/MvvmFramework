using System;
using System.Collections.Generic;

namespace MVVMFramework.Common
{
    /// <summary>
    /// Interface for filter collections
    /// </summary>
    /// <typeparam name="T">Type of collection items</typeparam>
    public interface IFilterCollection<T>
    {
        /// <summary>
        /// Gets or sets the default view
        /// </summary>
        List<T> DefaultView { get; set; }

        /// <summary>
        /// Gets or sets the filter function
        /// </summary>
        Func<T, bool> Filter { get; set; }

        /// <summary>
        /// Filters the default view
        /// </summary>
        void Refresh();
    }
}
