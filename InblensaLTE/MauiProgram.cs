using InblensaLTE.Pages;
using InblensaLTE.Services;
using InblensaLTE.ViewModels;
using Microsoft.Extensions.Logging;

namespace InblensaLTE;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<ApiService>();
        
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<LoadingPageViewModel>();

        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddSingleton<InventoriesPage>();
        builder.Services.AddSingleton<InventoryViewModel>();
        
        
        var app = builder.Build();
        ServiceLocator.Init(app.Services);

        return app;
    }
}