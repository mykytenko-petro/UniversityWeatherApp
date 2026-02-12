using Gtk;
using UniversityWeatherApp.Core;
using UniversityWeatherApp.UI;
using UniversityWeatherApp.UI.Pages;

namespace UniversityWeatherApp;

class Program
{
    private static AppState _appState;

    [STAThread]
    public static void Main()
    {
        Application.Init();

        var app = new Application("org.UniversityWeatherApp.UniversityWeatherApp", GLib.ApplicationFlags.None);
        app.Register(GLib.Cancellable.Current);

        _appState = new AppState();

        SetupEssentials();

        var win = new MainWindow(_appState);
        app.AddWindow(win);

        win.ShowAll();
        Application.Run();
    }

    private static void SetupEssentials()
    {   
        _appState.PageService.CreatePages(
            new[]
            {
                typeof(Dashboard)
            },
            _appState
        );
        _appState.StyleService.LoadStyles();
    }
}
