using System.Collections.Specialized;

namespace MyApp.ViewModels;

public class PickerWorkaroundPageViewModel : ViewModelBase
{
    [Reactive] public ObservableCollection<AccountEditViewModel> AccountList { get; set; }

    protected override async Task OnInitializeAsync( CancellationToken cancellationToken )
    {
        await base.OnInitializeAsync( cancellationToken );

        var categoryNames = new List<string> { "cat 1", "cat 2", "cat 3" };

        var accounts = new List<Account>
        {
            new Account { CategoryName = "cat 1", Name = "name 1", Number = "001", },
            new Account { CategoryName = "cat 1", Name = "name 2", Number = "002", },
            new Account { CategoryName = "cat 2", Name = "name 3", Number = "003", },
        };

        AccountList = new ObservableCollection<AccountEditViewModel>( accounts.Select( e => new AccountEditViewModel { Account = e, CategoryNames = categoryNames, } ) );
    }
}
