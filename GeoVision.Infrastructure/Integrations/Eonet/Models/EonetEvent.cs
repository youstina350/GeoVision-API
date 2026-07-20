using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Eonet.Models;

public class EonetEvent
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("categories")]
    public List<EonetCategory> Categories { get; set; } = [];

    [JsonPropertyName("geometry")]
    public List<EonetGeometry> Geometry { get; set; } = [];
}