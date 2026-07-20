using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Earthquake.Models;

public class UsgsGeometry
{
    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; } = [];
}