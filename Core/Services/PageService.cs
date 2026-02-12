using Gtk;
using UniversityWeatherApp.Core.UI;

namespace UniversityWeatherApp.Core.Services;

public class PageService
{
    private readonly Dictionary<Type, Page> Pages = new();
    public Type CurrentPage {get; private set;}

    public void CreatePages(Type[] PageTypes, AppState appState)
    {
        foreach (Type type in PageTypes)
            // 
            Pages.Add(type, (Page)Activator.CreateInstance(type, appState));
    }

    public void ChangePage(Type pageType, Window window)
    {
        if (CurrentPage != null)
            window.Remove(Pages[CurrentPage]);

        window.Add(Pages[pageType]);

        CurrentPage = pageType;
    }
}