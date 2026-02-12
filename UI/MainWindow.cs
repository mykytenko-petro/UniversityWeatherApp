using Gtk;
using UniversityWeatherApp.Config;
using UniversityWeatherApp.Core;
using UniversityWeatherApp.UI.Pages;

namespace UniversityWeatherApp.UI;

class MainWindow : Window
{
    private AppState _appState;

    public MainWindow(AppState appState) : base("University Weather App")
    {
        _appState = appState;

        SetDefaultSize(
            WindowSettings.Width,
            WindowSettings.Height
        );

        DeleteEvent += Window_DeleteEvent;

        _appState.PageService.ChangePage(typeof(Dashboard), this);
    }

    private void Window_DeleteEvent(object o, DeleteEventArgs a)
    {
        Application.Quit();
    }
}