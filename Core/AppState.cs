using UniversityWeatherApp.Core.Services;

namespace UniversityWeatherApp.Core;

public struct AppState
{
    public PageService PageService;
    public ResourceService ResourceService;
    public StyleService StyleService;

    public AppState()
    {
        PageService = new();
        ResourceService = new();
        StyleService = new(ResourceService);
    }
}