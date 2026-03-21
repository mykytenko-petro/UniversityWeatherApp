using System.Text.Json.Serialization;

namespace UniversityWeatherApp.Models;

public class SettingsModel
{
    [JsonPropertyName("OPEN_WEATER_MAP_API_KEY")]
    public required string ApiKey { get; set; }
}