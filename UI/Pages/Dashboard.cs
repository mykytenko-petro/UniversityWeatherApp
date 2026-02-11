using Gtk;

namespace UniversityWeatherApp.UI.Pages;

public class Dashboard : Box
{
    public Dashboard() : base(Orientation.Horizontal, 0)
    {
        StyleContext.AddClass("Dashboard");
        Hexpand = true;
        Vexpand = true;

        // Button button = new();

        // Add(button);
    }
}