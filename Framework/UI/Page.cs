using Avalonia.Controls;
using UniversityWeatherApp.Framework.Mvvm;

namespace UniversityWeatherApp.Framework.UI;

public abstract class Page : ViewBase<Grid>
{
    protected Page(IServiceProvider serviceProvider) : base(serviceProvider) { }

    protected RowDefinitions RowDefinitions
    {
        get => Root.RowDefinitions;
        set => Root.RowDefinitions = value;
    }

    protected ColumnDefinitions ColumnDefinitions
    {
        get => Root.ColumnDefinitions;
        set => Root.ColumnDefinitions = value;
    }

    protected void Add(Control item)
    {
        Root.Children.Add(item);
    }
}