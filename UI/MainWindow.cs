using Gtk;
using UniversityWeatherApp.Core.Config;
using UniversityWeatherApp.UI.Pages;

namespace UniversityWeatherApp.UI;

class MainWindow : Window
{
    public MainWindow() : base("University Weather App")
    {
        SetDefaultSize(
            WindowSettings.Width,
            WindowSettings.Height
        );

        DeleteEvent += Window_DeleteEvent;

        SetupUI();
    }

    private void SetupUI()
    {
        Dashboard dashboard = new();

        Add(dashboard);
    }

    private void Window_DeleteEvent(object o, DeleteEventArgs a)
    {
        Application.Quit();
    }
}