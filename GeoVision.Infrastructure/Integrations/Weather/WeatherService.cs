using System.Net.Http.Json;
using GeoVision.Application.Configurations;
using GeoVision.Application.DTOs.Weather;
using GeoVision.Application.Exceptions;
using GeoVision.Application.Interfaces.External;
using GeoVision.Infrastructure.Integrations.Weather.Models;
using Microsoft.Extensions.Options;

namespace GeoVision.Infrastructure.Integrations.Weather;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly WeatherApiOptions _options;

    public WeatherService(
        HttpClient httpClient,
        IOptions<WeatherApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<CurrentWeatherDto> GetCurrentWeatherAsync(string city)
    {
        var weatherResponse = await _httpClient.GetFromJsonAsync<WeatherApiResponse>(
            $"weather?q={city}&appid={_options.ApiKey}&units=metric");

        if (weatherResponse is null)
        {
            throw new NotFoundException("City not found.");
        }

        return new CurrentWeatherDto
        {
            City = weatherResponse.Name,
            Temperature = weatherResponse.Main.Temperature,
            Humidity = weatherResponse.Main.Humidity,
            WindSpeed = weatherResponse.Wind.Speed,
            Condition = weatherResponse.Weather.FirstOrDefault()?.Main ?? "Unknown",
            Description = weatherResponse.Weather.FirstOrDefault()?.Description ?? "Unknown"
        };
    }
}