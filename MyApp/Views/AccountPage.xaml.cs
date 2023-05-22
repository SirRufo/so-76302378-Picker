namespace MyApp.Views;

public partial class AccountPage : ContentPage
{
    public AccountPage( AccountPageViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }
}
