using Avalonia.Controls;
using UniversityWeatherApp.Config;
using UniversityWeatherApp.Views.Pages;

namespace UniversityWeatherApp.Views;

public partial class MainWindow : Window
{


    public MainWindow()
    {
        Width = WindowSettings.Width;
        Height = WindowSettings.Height;

        Content = new DashboardView();
    }
}