using MVVMFramework.Framework;
using MVVMFramework.Sample.WPF.Models;
using MVVMFramework.ViewProperties;
using System.Collections.ObjectModel;

namespace MVVMFramework.Sample.WPF.ViewProperties
{
    class TestProperties : ViewPropertyBase
    {
        private Command addCommand;
        private string name;
        private ObservableCollection<Person> personList;
        private string surname;
        private Command updateEntryCommand;

        public Command AddCommand
        {
            get
            {
                return this.addCommand;
            }
            set
            {
                this.Set(() => this.AddCommand, ref this.addCommand, value);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.Set(() => this.Name, ref this.name, value);
            }
        }

        public ObservableCollection<Person> PersonList
        {
            get
            {
                return this.personList;
            }
            set
            {
                this.Set(() => this.PersonList, ref this.personList, value);
            }
        }

        public string Surname
        {
            get
            {
                return this.surname;
            }
            set
            {
                this.Set(() => this.Surname, ref this.surname, value);
            }
        }

        public Command UpdateEntryCommand
        {
            get
            {
                return this.updateEntryCommand;
            }
            set
            {
                this.Set(() => this.UpdateEntryCommand, ref this.updateEntryCommand, value);
            }
        }

    }
}
