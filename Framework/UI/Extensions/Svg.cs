using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Svg;
using UniversityWeatherApp.Framework.Utils;

namespace UniversityWeatherApp.Framework.UI.Extensions;

public static partial class UIExtensions
{
    public static Image SvgSource(this Image image, string pathToSvg)
    {
        image.Source = new SvgImage()
        {
            Source = ResourceUtils.GetAssetSvg(pathToSvg)
        };

        return image;
    }

    public static Image SvgSource(this Image image, IBinding binding)
    {
        image.Bind(Image.SourceProperty, binding);

        return image;
    }
}