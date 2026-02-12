using Gtk;

namespace UniversityWeatherApp.UI.Components.Dashboard;

public class SidePanelComponent : Box
{
    public SidePanelComponent() : base(Orientation.Vertical, 40)
    {
        WidthRequest = 526;

        Halign = Align.End;
        Valign = Align.Fill;

        StyleContext.AddClass("SidePanel");

        PackStart(new Label("Side Panel"), false, false, 10);
    }
}