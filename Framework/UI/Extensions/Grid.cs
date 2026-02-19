using Avalonia.Controls;

namespace UniversityWeatherApp.Framework.UI.Extensions;

public static partial class UIExtensions
{
    public static Control SetGridRow(this Control control, int value)
    {
        Grid.SetRow(control, value);

        return control;
    }

    public static Control SetGridColumn(this Control control, int value)
    {
        Grid.SetColumn(control, value);

        return control;
    }

    public static Control SetGridRowSpan(this Control control, int value)
    {
        Grid.SetRowSpan(control, value);

        return control;
    }

    public static Control SetGridColumnSpan(this Control control, int value)
    {
        Grid.SetColumnSpan(control, value);

        return control;
    }
}