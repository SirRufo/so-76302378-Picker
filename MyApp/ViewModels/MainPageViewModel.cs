namespace MyApp.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    [Reactive] public ObservableCollection<Account> AccountList { get; set; }
    [Reactive] public Account AccountListSelectedItem { get; set; }
    [Reactive] public ObservableCollection<string> CategoryNames { get; set; }

    protected override async Task OnInitializeAsync( CancellationToken cancellationToken )
    {
        await base.OnInitializeAsync( cancellationToken );
        AccountList = new ObservableCollection<Account>(
            new[]
            {
                new Account { CategoryName = "cat 1", Name = "name 1", Number = "001", },
                new Account { CategoryName = "cat 1", Name = "name 2", Number = "002", },
                new Account { CategoryName = "cat 2", Name = "name 3", Number = "003", },
            } );

        CategoryNames = new ObservableCollection<string>(
            new[]
            {
                "cat 1", "cat 2", "cat 3",
            } );
    }
}
