namespace MyApp.ViewModels;

public class BindingSourcePageViewModel : ViewModelBase
{
    [Reactive] public string Value { get; set; } = "Hello World";

    public IList<int> Items { get; } = new List<int> { 1, }.AsReadOnly();
}