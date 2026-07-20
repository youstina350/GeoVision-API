namespace GeoVision.Application.DTOs.Eonet;

public class EventDto
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}