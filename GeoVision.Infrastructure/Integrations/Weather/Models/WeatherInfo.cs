using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Weather.Models;

public class WeatherInfo
{
    [JsonPropertyName("main")]
    public string Main { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}