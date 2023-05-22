using System.Reactive;

namespace MyApp.ViewModels;

[QueryProperty( nameof( Case ), "case" )]
public class AccountPageViewModel : ViewModelBase
{
    [Reactive] public ObservableCollection<Account> AccountList { get; set; }
    [Reactive] public ObservableCollection<string> CategoryNames { get; set; }
    [Reactive] public Account Account { get; set; }

    [Reactive] public string Case { get; set; }
    public ObservableCollection<string> Protocol { get; } = new();

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
                await PopulateAccountListAsync();
                await PopulateCategoryNamesAsync();
                break;
            case "2":
                await PopulateAccountAsync();
                await PopulateCategoryNamesAsync();
                await PopulateAccountListAsync();
                break;
            case "3":
                await PopulateCategoryNamesAsync();
                await PopulateAccountAsync();
                await PopulateAccountListAsync();
                break;
            case "4":
                await PopulateCategoryNamesAsync();
                await PopulateAccountAsync();
                await Task.Delay( 20 );
                await PopulateAccountListAsync();
                await Task.Delay( 20 );
                break;
            case "5":
                await PopulateCategoryNamesAsync();
                await PopulateAccountAsync();
                await Task.Delay( 20 );
                await PopulateAccountListAsync();
                await Task.Delay( 20 );
                await PopulateAccountListAsync();
                await Task.Delay( 20 );
                break;
            default:
                break;
        }
    }

    protected Task PopulateCategoryNamesAsync()
    {
        Protocol.Add( "Populate CategoryNames" );
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
        Protocol.Add( "Populate Account" );
        Account = new Account { CategoryName = "cat 2", Name = "name 4", Number = "004", };
        return Task.CompletedTask;
    }

    protected Task PopulateAccountListAsync()
    {
        Protocol.Add( "Populate AccountList" );
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
