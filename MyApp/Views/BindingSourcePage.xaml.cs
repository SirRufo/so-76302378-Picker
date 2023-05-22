namespace MyApp.Views;

public partial class BindingSourcePage : ContentPage
{
    public BindingSourcePage( BindingSourcePageViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }
}
