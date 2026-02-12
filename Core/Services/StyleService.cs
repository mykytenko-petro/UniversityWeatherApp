using Gtk;

namespace UniversityWeatherApp.Core.Services;

/// <summary>
/// 
/// </summary>
public class StyleService
{
    private ResourceService _resourceService;

    public StyleService(ResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    public void LoadStyles()
    {
        CssProvider cssProvider = new();

        // 
        cssProvider.LoadFromData(_resourceService.GetCssText());

        // 
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            StyleProviderPriority.Application
        );
    }
}