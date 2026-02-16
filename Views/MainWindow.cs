using Avalonia.Controls;
using Avalonia.Platform;
using UniversityWeatherApp.Config;
using UniversityWeatherApp.Views.ApplicationStyles;
using UniversityWeatherApp.Views.Pages;

namespace UniversityWeatherApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
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
        Content = new DashboardView();
    }
}