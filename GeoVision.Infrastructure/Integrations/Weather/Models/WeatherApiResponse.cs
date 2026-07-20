using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Weather.Models;

public class WeatherApiResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("main")]
    public MainInfo Main { get; set; } = new();

    [JsonPropertyName("wind")]
    public WindInfo Wind { get; set; } = new();

    [JsonPropertyName("weather")]
    public List<WeatherInfo> Weather { get; set; } = new();
}