using System.Text.Json;
using GeoVision.Application.Configurations;
using GeoVision.Application.DTOs.Earthquake;
using GeoVision.Application.Interfaces.External;
using GeoVision.Infrastructure.Integrations.Earthquake.Models;
using Microsoft.Extensions.Options;

namespace GeoVision.Infrastructure.Integrations.Earthquake;

public class EarthquakeService : IEarthquakeService
{
    private readonly HttpClient _httpClient;
    private readonly UsgsApiOptions _options;

    public EarthquakeService(
        HttpClient httpClient,
        IOptions<UsgsApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<List<EarthquakeDto>> GetRecentEarthquakesAsync()
    {
        var response = await _httpClient.GetAsync(
            "query?format=geojson&limit=20&orderby=time&minmagnitude=3");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Unable to retrieve earthquake data.");
        }

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<UsgsResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (result is null)
        {
            throw new Exception("Invalid earthquake data.");
        }

        return result.Features.Select(e => new EarthquakeDto
        {
            Id = e.Id,
            Title = e.Properties.Title,
            Place = e.Properties.Place,
            Magnitude = e.Properties.Magnitude ?? 0,
            Longitude = e.Geometry.Coordinates.ElementAtOrDefault(0),
            Latitude = e.Geometry.Coordinates.ElementAtOrDefault(1),
            Depth = e.Geometry.Coordinates.ElementAtOrDefault(2),
            Time = DateTimeOffset
                        .FromUnixTimeMilliseconds(e.Properties.Time)
                        .UtcDateTime,
            Status = e.Properties.Status,
            Tsunami = e.Properties.Tsunami == 1,
            Url = e.Properties.Url
        }).ToList();
    }
}