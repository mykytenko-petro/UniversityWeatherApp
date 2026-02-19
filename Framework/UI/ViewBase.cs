using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI;

public abstract class ViewBase : UserControl
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