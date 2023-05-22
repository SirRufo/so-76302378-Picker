namespace MyApp.ViewModels;

public class BindingSourcePageViewModel : ViewModelBase
{
    [Reactive] public string Value { get; set; } = "Hello World";
}