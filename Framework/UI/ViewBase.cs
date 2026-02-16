using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI;

public abstract class ViewBase : Panel
{
    protected ViewBase() : base()
    {
        Setup();
        LayoutStyles();
        Layout();
    }

    protected virtual void Setup() { }

    protected virtual void LayoutStyles() { }

    protected abstract void Layout();
}