using Gtk;
using UniversityWeatherApp.Core.UI;

namespace UniversityWeatherApp.UI.Pages;

public class Dashboard : Box
{
    private GImage _background;

    public Dashboard() : base(Orientation.Horizontal, 0)
    {
        StyleContext.AddClass("Dashboard");
        Hexpand = true;
        Vexpand = true;

        _background = new("Background/Snow.png")
        {
            Hexpand = true,
            Vexpand = true
        };
        Add(_background);
    }
}