using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using UniversityWeatherApp.Framework.UI;
using UniversityWeatherApp.Views.Pages;

namespace UniversityWeatherApp.Services;

public sealed class NavigationService
{
    private Dictionary<string, Page> Pages { get; }

    private Window _window;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _window = serviceProvider.GetRequiredService<Window>();

        Pages = new Dictionary<string, Page>
        {
            { "Dashboard", new DashboardView(serviceProvider) },
            { "Settings", new SettingsView(serviceProvider) }
        };
    }

    public void ChangePage(string name)
    {
        _window.Content = Pages[name];
    }
}