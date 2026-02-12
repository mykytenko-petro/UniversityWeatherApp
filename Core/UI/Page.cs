using Gtk;

namespace UniversityWeatherApp.Core.UI;

public abstract class Page : Box
{
    protected Overlay _overlay;
    protected AppState _appState;

    protected Page(AppState appState) : base(Orientation.Horizontal, 0)
    {
        _overlay = new();
        _appState = appState;

        Hexpand = true;
        Vexpand = true;

        Layout();

        Add(_overlay);
    }

    protected abstract void Layout();
}