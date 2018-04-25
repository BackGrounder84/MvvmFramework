using MVVMFramework.Framework;
using MVVMFramework.Sample.WPF.Models;
using MVVMFramework.Sample.WPF.ViewProperties;
using MVVMFramework.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMFramework.Sample.WPF.ViewModels
{
    class TestViewModel : ViewModelBase<TestProperties>
    {
        public override void Init(object obj = null)
        {
            base.Init(obj);

            this.Properties.PersonList = new ObservableCollection<Person>();
            this.Properties.AddCommand = new Command(this.AddCommandAction);
            this.Properties.UpdateEntryCommand = new Command(this.UpdateEntryCommandAction);
        }

        private void UpdateEntryCommandAction()
        {
            if (!string.IsNullOrEmpty(this.Properties.Name) 
                && !string.IsNullOrEmpty(this.Properties.Surname) 
                && this.Properties.PersonList.Count > 0)
            {
                var person = this.Properties.PersonList.FirstOrDefault();
                person.Name = this.Properties.Name;
                person.Surname = this.Properties.Surname;
            }
        }

        private void AddCommandAction()
        {
            if (!string.IsNullOrEmpty(this.Properties.Name) && !string.IsNullOrEmpty(this.Properties.Surname))
            {
                var person = new Person() { Name = this.Properties.Surname, Surname = this.Properties.Surname };
                this.Properties.PersonList.Add(person);
            }
        }
    }
}
