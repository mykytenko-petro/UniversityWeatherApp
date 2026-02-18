using Avalonia;
using Avalonia.Styling;

namespace UniversityWeatherApp.Framework.UI.Extensions;

public static partial class UIExtensions
{
    public static Style Add(this Style control, AvaloniaProperty property, object value)
    {
        if (value.GetType() == typeof(int))
            value = Convert.ToDouble(value);

        control.Setters.Add(new Setter(property, value));

        return control;
    }
}