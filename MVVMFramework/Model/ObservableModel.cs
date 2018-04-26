using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MVVMFramework.Model
{
    /// <summary>
    /// The base for an observable object
    /// </summary>
    public abstract class ObservableModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Throws only a PropertyChangedEvent changed event
        /// </summary>
        /// <typeparam name="T">Type of the property></typeparam>
        /// <param name="expression">Expression of the property; ()=> this.[PropName]</param>
        protected void Notify<T>(Expression<Func<T>> expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            this.OnPropertyChanged(memberExpression.Member.Name);
        }

        /// <summary>
        /// Throws only a PropertyChangedEvent changed event
        /// </summary>
        /// <param name="propName">The property name</param>
        protected void Notify(string propName)
        {
            this.OnPropertyChanged(propName);
        }

        /// <summary>
        /// Sets a property and throws PropertyChangedEvent event
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="expression">Expression of the property; ()=> this.[PropName]</param>
        /// <param name="field">The reference of the field</param>
        /// <param name="value">The value to be set</param>
        protected void Set<T>(Expression<Func<T>> expression, ref T field, T value)
        {
            if (field == null || !field.Equals(value))
            {
                field = value;

                MemberExpression memberExpression = (MemberExpression)expression.Body;
                this.OnPropertyChanged(memberExpression.Member.Name);
            }
        }

        /// <summary>
        /// Sets a property and throws PropertyChangedEvent event
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="propName">The property name</param>
        /// <param name="field">The reference of the field</param>
        /// <param name="value">The value to be set</param>
        protected void Set<T>(string propName, ref T field, T value)
        {
            if (field == null || !field.Equals(value))
            {
                this.OnPropertyChanged(propName);
            }
        }

        /// <summary>
        /// Throws PropertyChangedEvent
        /// </summary>
        /// <param name="name">Property name</param>
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
