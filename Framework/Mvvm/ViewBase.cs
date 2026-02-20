using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.Mvvm;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ViewBase<T> : UserControl where T : Panel, new()
{
    protected IServiceProvider? _serviceProvider;

    protected T Root;
    
    protected ViewBase(IServiceProvider? serviceProvider = null) : base()
    {
        _serviceProvider = serviceProvider;

        Root = new T();

        LayoutStyles();
        Layout();

        Content = Root;
    }

    protected virtual void LayoutStyles() { }

    protected abstract void Layout();
}