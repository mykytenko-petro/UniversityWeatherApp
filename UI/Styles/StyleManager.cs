using Gtk;
using UniversityWeatherApp.Core.Services;

namespace UniversityWeatherApp.UI.Styles;

/// <summary>
/// 
/// </summary>
public static class StyleManager
{
    public static void Load(ResourceService resourceService)
    {
        CssProvider cssProvider = new();

        // 
        foreach (var text in resourceService.GetCssText())
        {
            cssProvider.LoadFromData(text);
        }

        // 
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            StyleProviderPriority.Application
        );
    }
}