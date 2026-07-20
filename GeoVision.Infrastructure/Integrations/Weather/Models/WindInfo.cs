using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Weather.Models;

public class WindInfo
{
    [JsonPropertyName("speed")]
    public double Speed { get; set; }
}