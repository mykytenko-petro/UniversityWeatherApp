using Gtk;

namespace UniversityWeatherApp.Core.Services;

public class PageService
{
    private readonly Dictionary<Type, Box> Pages = new();
    public Type CurrentPage {get; private set;}

    public void CreatePages(Type[] PageTypes, AppState appState)
    {
        foreach (Type type in PageTypes)
            // 
            Pages.Add(type, (Box)Activator.CreateInstance(type, appState));
    }

    public void ChangePage(Type pageType, Window window)
    {
        if (CurrentPage != null)
            window.Remove(Pages[CurrentPage]);

        window.Add(Pages[pageType]);

        CurrentPage = pageType;
    }
}