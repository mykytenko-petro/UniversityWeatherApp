using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI;

public abstract class ViewBase : Panel
{
    protected ViewBase() : base()
    {
        Setup();
        Layout();
    }

    protected virtual void Setup() { }

    protected abstract void Layout();
}