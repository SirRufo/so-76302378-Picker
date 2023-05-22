namespace MyApp;

public partial class MainPage : ContentPage
{
    public MainPage( MainPageViewModel viewModel )
    {
        InitializeComponent();
        BindingContext = viewModel;
        Appearing += async ( s, e ) => await viewModel.InitializeAsync();
    }

    async void Case1Button_Clicked( System.Object sender, System.EventArgs e )
    {
        await Shell.Current.GoToAsync( "account?case=1" );
    }

    async void Case2Button_Clicked( System.Object sender, System.EventArgs e )
    {
        await Shell.Current.GoToAsync( "account?case=2" );
    }

    async void Case3Button_Clicked( System.Object sender, System.EventArgs e )
    {
        await Shell.Current.GoToAsync( "account?case=3" );
    }

    async void Case4Button_Clicked( System.Object sender, System.EventArgs e )
    {
        await Shell.Current.GoToAsync( "account?case=4" );
    }
}
