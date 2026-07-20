using GeoVision.Application.DTOs.Earthquake;

namespace GeoVision.Application.Interfaces.External;

public interface IEarthquakeService
{
    Task<List<EarthquakeDto>> GetRecentEarthquakesAsync();
}