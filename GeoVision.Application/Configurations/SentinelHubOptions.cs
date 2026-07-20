namespace GeoVision.Application.Configurations;

public class SentinelHubOptions
{
    public const string SectionName = "SentinelHub";

    public string BaseUrl { get; set; } = string.Empty;

    public string ClientId { get; set; } = string.Empty;

    public string ClientSecret { get; set; } = string.Empty;
}