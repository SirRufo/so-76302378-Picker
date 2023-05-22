using System.Reactive;

namespace MyApp.ViewModels;

[QueryProperty( nameof( Case ), "case" )]
public class AccountPageViewModel : ViewModelBase
{
    [Reactive] public ObservableCollection<Account> AccountList { get; set; }
    [Reactive] public ObservableCollection<string> CategoryNames { get; set; }
    [Reactive] public Account Account { get; set; }

    [Reactive] public string Case { get; set; }

    public ReactiveCommand<Unit, Unit> ReloadCategoryNamesCommand { get; }
    public ReactiveCommand<Unit, Unit> ReloadAccountCommand { get; }
    public ReactiveCommand<Unit, Unit> ReloadAccountListCommand { get; }

    public AccountPageViewModel()
    {
        ReloadCategoryNamesCommand = ReactiveCommand.CreateFromTask( PopulateCategoryNamesAsync );
        ReloadAccountCommand = ReactiveCommand.CreateFromTask( PopulateAccountAsync );
        ReloadAccountListCommand = ReactiveCommand.CreateFromTask( PopulateAccountListAsync );
    }

    protected override async Task OnInitializeAsync( CancellationToken cancellationToken )
    {
        await base.OnInitializeAsync( cancellationToken );

        switch ( Case )
        {
            case "1":
                await PopulateAccountAsync();
                await PopulateCategoryNamesAsync();
                await PopulateAccountListAsync();
                break;
            case "2":
                await PopulateAccountListAsync();
                await PopulateAccountAsync();
                await PopulateCategoryNamesAsync();
                break;
            case "3":
                await PopulateAccountListAsync();
                await PopulateCategoryNamesAsync();
                await PopulateAccountAsync();
                break;
            default:
                await PopulateCategoryNamesAsync();
                await PopulateAccountAsync();
                await PopulateAccountListAsync();
                break;
        }
    }

    protected Task PopulateCategoryNamesAsync()
    {
        CategoryNames = new ObservableCollection<string>(
            new[]
            {
                "cat 1",
                "cat 2",
                "cat 3",
            } );
        return Task.CompletedTask;
    }

    protected Task PopulateAccountAsync()
    {
        Account = new Account { CategoryName = "cat 2", Name = "name 4", Number = "004", };
        return Task.CompletedTask;
    }

    protected Task PopulateAccountListAsync()
    {
        AccountList = new ObservableCollection<Account>(
            new[]
            {
                new Account { CategoryName = "cat 1", Name = "name 1", Number = "001", },
                new Account { CategoryName = "cat 1", Name = "name 2", Number = "002", },
                new Account { CategoryName = "cat 2", Name = "name 3", Number = "003", },
            } );

        return Task.CompletedTask;
    }
}
