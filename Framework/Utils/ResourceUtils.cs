using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Svg;

namespace UniversityWeatherApp.Framework.Utils;

public static class ResourceUtils
{
    public static Bitmap GetAssetBitmap(string uri) =>
        new(AssetLoader.Open(new Uri($"avares://UniversityWeatherApp/Assets/{uri}")));

    public static SvgSource GetAssetSvg(string uri) =>
        SvgSource.Load(
            AssetLoader.Open(new Uri($"avares://UniversityWeatherApp/Assets/{uri}")));

    public static SvgImage GetSvgImage(string uri) =>
        new() { Source = GetAssetSvg(uri) };
}