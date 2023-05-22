namespace MyApp;

public partial class AppShell : Shell
{
    public AppShell( AppShellViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }
}

