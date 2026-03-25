using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Services;

namespace UniversityWeatherApp;

public partial class App : Application
{
    public override void Initialize()
    {
        var apiKeyService = Program.ServiceProvider.GetRequiredService<ApiKeyService>();

        Dispatcher.UIThread.Post(async () =>
        {
            await apiKeyService.Setup(); 
        });
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var navigationService = Program.ServiceProvider.GetRequiredService<NavigationService>();
            navigationService.AddWindow(Program.ServiceProvider);
            navigationService.ChangePage("Dashboard");

            desktop.MainWindow = navigationService._window;
        }

        base.OnFrameworkInitializationCompleted();
    }
}