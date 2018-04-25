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
    if (!string.IsNullOrEmpty(this.Properties.Name) && !string.IsNullOrEmpty(this.Properties.Surname))
    {
        ...
    }
}
````
## Usage
````
this.vm = new TestViewModel();
this.vm.Init();
this.DataContext = this.vm;
````
