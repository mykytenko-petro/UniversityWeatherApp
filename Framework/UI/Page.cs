using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI;

public abstract class Page : UserControl
{
    protected Page() : base()
    {
        Layout();
    }

    protected abstract void Layout();
}