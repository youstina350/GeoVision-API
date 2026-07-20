using System.Text.Json.Serialization;

namespace GeoVision.Infrastructure.Integrations.Earthquake.Models;

public class UsgsProperties
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("place")]
    public string Place { get; set; } = string.Empty;

    [JsonPropertyName("mag")]
    public double? Magnitude { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("tsunami")]
    public int Tsunami { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}