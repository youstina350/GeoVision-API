using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Eonet.Models;

public class EonetGeometry
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; } = [];
}