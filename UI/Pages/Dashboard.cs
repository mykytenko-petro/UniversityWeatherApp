using Gtk;
using UniversityWeatherApp.Core;
using UniversityWeatherApp.Core.UI;
using UniversityWeatherApp.UI.Components.Dashboard;

namespace UniversityWeatherApp.UI.Pages;

public class Dashboard : Page
{
    private GImage background;
    private SidePanelComponent sidePanelComponent;

    public Dashboard(AppState appState) : base(appState)
    {
        StyleContext.AddClass("Dashboard");
    }

    protected override void Layout()
    {
        background = new("Background/Snow.png", _appState.ResourceService)
        {
            Hexpand = true,
            Vexpand = true
        };
        _overlay.Add(background);

        sidePanelComponent = new();
        _overlay.AddOverlay(sidePanelComponent);
    }
}