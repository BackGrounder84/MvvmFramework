using MVVMFramework.Model;

namespace MVVMFramework.Sample.WPF.Models
{
    class Person : ObservableModel
    {
        private string name;
        private string surname;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.Set(() => this.Name, ref this.name, value);

                //Notification for the readonly property to update the UI
                this.Notify(() => this.CompleteName);
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

                //Notification for the readonly property to update the UI
                this.Notify(() => this.CompleteName);
            }
        }

        public string CompleteName
        {
            get
            {
                return $"{this.Surname}, {this.Name}";
            }
        }
    }
}
