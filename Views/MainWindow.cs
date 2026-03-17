using Avalonia.Controls;
using Avalonia.Platform;
using UniversityWeatherApp.Config;
using UniversityWeatherApp.Views.Styles;
using UniversityWeatherApp.Views.Pages;

namespace UniversityWeatherApp.Views;

public partial class MainWindow : Window
{
    public MainWindow(IServiceProvider serviceProvider)
    {
        // window settings
        Width = WindowSettings.Width;
        Height = WindowSettings.Height;

        Icon = new WindowIcon(
            AssetLoader.Open(new Uri("avares://UniversityWeatherApp/Assets/" + WindowSettings.IconPath))
        );
        Title = WindowSettings.Title;

        // styles
        Styles.Add(new AppStyles());

        // views
        // TODO: make navigation
        Content = new DashboardView(serviceProvider);
    }
}