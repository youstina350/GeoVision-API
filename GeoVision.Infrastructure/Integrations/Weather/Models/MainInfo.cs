using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Weather.Models;

public class MainInfo
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
}