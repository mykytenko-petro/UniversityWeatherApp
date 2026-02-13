namespace UniversityWeatherApp.Framework.UI;

public abstract class Page
{
    protected Page()
    {
        Layout();
    }

    protected abstract void Layout();
}