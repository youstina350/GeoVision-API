using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Earthquake.Models;

public class UsgsFeature
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("properties")]
    public UsgsProperties Properties { get; set; } = new();

    [JsonPropertyName("geometry")]
    public UsgsGeometry Geometry { get; set; } = new();
}