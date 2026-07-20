namespace GeoVision.Application.DTOs.Earthquake;

public class EarthquakeDto
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Place { get; set; } = string.Empty;

    public double Magnitude { get; set; }

    public double Depth { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public DateTime Time { get; set; }

    public string Status { get; set; } = string.Empty;

    public bool Tsunami { get; set; }

    public string Url { get; set; } = string.Empty;
}