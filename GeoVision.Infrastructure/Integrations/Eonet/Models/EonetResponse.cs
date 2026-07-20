using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Eonet.Models;

public class EonetResponse
{
    [JsonPropertyName("events")]
    public List<EonetEvent> Events { get; set; } = [];
}