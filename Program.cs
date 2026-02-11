using Gtk;
using UniversityWeatherApp.UI;
using UniversityWeatherApp.UI.Styles;

namespace UniversityWeatherApp;

class Program
{
    [STAThread]
    public static void Main()
    {
        Application.Init();

        var app = new Application("org.UniversityWeatherApp.UniversityWeatherApp", GLib.ApplicationFlags.None);
        app.Register(GLib.Cancellable.Current);

        SetupEssentials();

        var win = new MainWindow();
        app.AddWindow(win);

        win.ShowAll();
        Application.Run();
    }

    private static void SetupEssentials()
    {
        StyleManager.Load();
    }
}
