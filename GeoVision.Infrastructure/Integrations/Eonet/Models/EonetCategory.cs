using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Eonet.Models;

public class EonetCategory
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
}