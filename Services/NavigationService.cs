using Avalonia.Controls;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.Views;
using UniversityWeatherApp.Views.Pages;

namespace UniversityWeatherApp.Services;

public sealed class NavigationService
{
    private Dictionary<string, Page>? Pages;

    public Window? _window;

    public void AddWindow(IServiceProvider serviceProvider)
    {
        _window = new MainWindow(serviceProvider);

        Pages = new Dictionary<string, Page>
        {
            { "Dashboard", new DashboardView(serviceProvider) },
            { "Settings", new SettingsView(serviceProvider) }
        };
    }

    public void ChangePage(string name)
    {
        _window!.Content = Pages![name];
    }
}