using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.Debug;
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
        // dependency injection setup
        var services = new ServiceCollection();

        services.AddSingleton<DebugService>();
        services.AddSingleton<WeatherService>();

        ServiceProvider = services.BuildServiceProvider();

        // avalonia app setup
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
