using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using UniversityWeatherApp.Framework.Debug;
using UniversityWeatherApp.Framework.Mvvm;
using UniversityWeatherApp.Services;
using UniversityWeatherApp.Views;

namespace UniversityWeatherApp;

public partial class App : Application
{
    public override void Initialize()
    {
        DataTemplates.Add(new ViewLocator());

        // debug
        DebugLogic();

        // weather api call
        var weatherService = Program.ServiceProvider.GetRequiredService<WeatherService>();

        var result = Task.Run(
            async () => await weatherService.GetTodaysWeather("Dnipro")).Result;

        // Console.WriteLine(result);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();

            desktop.MainWindow = new MainWindow(
                Program.ServiceProvider
            );
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

    private void DebugLogic()
    {
        var debugService = Program.ServiceProvider.GetRequiredService<DebugService>();
        if (!debugService.Debug)
            return;

        // weather service
        var weatherService = Program.ServiceProvider.GetRequiredService<WeatherService>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var result = Task.Run(
            async () => await weatherService.Connect(debugService.EvnVariables["OPEN_WEATER_MAP_API_KEY"])).Result;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        Console.WriteLine(result);
    }
}