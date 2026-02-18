using Avalonia.Styling;

namespace UniversityWeatherApp.Framework.UI;

/// <summary>
/// 
/// </summary>
public abstract class ViewStyles : Styles
{
    protected ViewStyles() : base()
    {
        Controls();
        Commons();
        Widgets();
    }

    protected virtual void Controls() { }

    protected virtual void Commons() { }

    protected virtual void Widgets() { }
}