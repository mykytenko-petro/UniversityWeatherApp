using System.IO;
using System.Text.Json;

namespace UniversityWeatherApp.Services;

public sealed class StorageService
{
    private static readonly string FolderName = "UniversityWeatherApp";
    private readonly string RootPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        FolderName
    );

    public StorageService()
    {
        Directory.CreateDirectory(RootPath);
    }

    public T ReadData<T>(string filename)
    {
        var path = Path.Combine(RootPath, filename);

        var json = File.ReadAllText(path);

        T data = JsonSerializer.Deserialize<T>(json)!;

        return data;
    }

    public void WriteData<T>(string filename, T data)
    {
        var path = Path.Combine(RootPath, filename);
        var json = JsonSerializer.Serialize(data);

        File.WriteAllText(path, json);
    }
}