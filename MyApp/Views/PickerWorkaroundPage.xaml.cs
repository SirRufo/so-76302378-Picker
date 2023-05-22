namespace MyApp.Views;

public partial class PickerWorkaroundPage : ContentPage
{
    public PickerWorkaroundPage( PickerWorkaroundPageViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }
}
