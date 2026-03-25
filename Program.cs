using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp;

sealed class Program
{
#pragma warning disable CS8618
    public static IServiceProvider ServiceProvider { get; private set; }
#pragma warning restore CS8618

    [STAThread]
    public static void Main(string[] args)
    {
        SetupServices();

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    private static void SetupServices()
    {
        var services = new ServiceCollection();

        DebugService debugService = new();
        NavigationService navigationService = new();
        StorageService storageService = new();
        WindowPopupService windowPopupService = new();
        WeatherService weatherService = new(windowPopupService);
        ApiKeyService apiKeyService = new(
            navigationService,
            weatherService,
            storageService,
            debugService
        );

        services.AddSingleton(debugService);
        services.AddSingleton(navigationService);
        services.AddSingleton(storageService);
        services.AddSingleton(windowPopupService);
        services.AddSingleton(weatherService);
        services.AddSingleton(apiKeyService);

        ServiceProvider = services.BuildServiceProvider();
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
