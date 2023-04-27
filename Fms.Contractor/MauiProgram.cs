using Microsoft.Extensions.Logging;
using Fms.Contractor.Data;
using Microsoft.Extensions.Configuration;
using Syncfusion.Blazor;

namespace Fms.Contractor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSyncfusionBlazor();
        
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(config.GetValue<string>("syncfusionKey"));

        return builder.Build();
    }
}