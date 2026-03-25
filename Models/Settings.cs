using System.Text.Json.Serialization;

namespace UniversityWeatherApp.Models;

public class SettingsModel
{
    [JsonPropertyName("OPEN_WEATHER_MAP_API_KEY")]
    public required string ApiKey { get; set; }
    public string LastPickedCity { get; set; } = "Dnipro";
}