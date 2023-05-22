using Microsoft.Extensions.Logging;

namespace MyApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts( fonts =>
            {
                fonts.AddFont( "OpenSans-Regular.ttf", "OpenSansRegular" );
                fonts.AddFont( "OpenSans-Semibold.ttf", "OpenSansSemibold" );
            } );

        builder.Services
            .AddSingleton<AppShell>().AddSingleton<AppShellViewModel>()
            .AddTransient<MainPage>().AddTransient<MainPageViewModel>()
            .AddTransient<AccountPage>().AddTransient<AccountPageViewModel>()
            .AddTransient<BindingSourcePage>().AddTransient<BindingSourcePageViewModel>()
            .AddTransient<PickerWorkaroundPage>().AddTransient<PickerWorkaroundPageViewModel>()
            ;

        Routing.RegisterRoute( "account", typeof( AccountPage ) );

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

