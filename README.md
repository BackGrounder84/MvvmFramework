# MvvmFramework
Very lightweight MVVM Framework with separation of logic and properties in view model

## View Model
````
class TestViewModel : ViewModelBase<TestProperties>
{
    public override void Init(object obj = null)
    {
        base.Init(obj);

        ...
    }
}
````
## View Properties
````
class TestProperties : ViewPropertyBase
{
    ...
}
````
## Model
````
class Person : ObservableModel
{
    ...
}
````

## Property changed notifications

### Set
````
private string name;

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
````
### Notify
````
this.Notify(() => this.CompleteName);
````
## Commands
````
public override void Init(object obj = null)
{
    ...
    this.Properties.AddCommand = new Command(this.AddCommandAction);
    ...
}

private void AddCommandAction()
{
    ...
}
````
## Usage
### Initialization
````
var vm = new TestViewModel();
vm.Init();
this.DataContext = vm;
````
### Propertiy binding
````
<TextBox Text="{Binding Properties.Name}"/>
````
### Command binding
````
<Button Content="Add" Command="{Binding Properties.AddCommand}"  />
````
