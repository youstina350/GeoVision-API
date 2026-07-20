using GeoVision.Application.DTOs.Weather;

namespace GeoVision.Application.Interfaces.External;

public interface IWeatherService
{
    Task<CurrentWeatherDto> GetCurrentWeatherAsync(string city);
}