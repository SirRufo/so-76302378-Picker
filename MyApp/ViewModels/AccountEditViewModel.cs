namespace MyApp.ViewModels;

public class AccountEditViewModel : ViewModelBase
{
    [Reactive] public Account Account { get; set; }
    [Reactive] public IEnumerable<string> CategoryNames { get; set; }
}