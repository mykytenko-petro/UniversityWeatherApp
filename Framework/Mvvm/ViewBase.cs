using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.Mvvm;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ViewBase<T> : UserControl where T : Panel, new()
{
    protected T Root;

    protected ViewBase() : base()
    {
        Root = new T();

        LayoutStyles();
        Layout();

        Content = Root;
    }

    protected virtual void LayoutStyles() { }

    protected abstract void Layout();
}