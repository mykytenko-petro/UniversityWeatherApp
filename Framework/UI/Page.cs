using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI;

public abstract class Page : ViewBase
{
    private readonly Grid _grid = new();

    protected RowDefinitions RowDefinitions
    {
        get => _grid.RowDefinitions;
        set => _grid.RowDefinitions = value;
    }

    protected ColumnDefinitions ColumnDefinitions
    {
        get => _grid.ColumnDefinitions;
        set => _grid.ColumnDefinitions = value;
    }

    protected Page() : base()
    {
        Children.Add(_grid);
    }

    protected void Add(Control item)
    {
        _grid.Children.Add(item);
    }
}