using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Earthquake.Models;

public class UsgsResponse
{
    [JsonPropertyName("features")]
    public List<UsgsFeature> Features { get; set; } = [];
}