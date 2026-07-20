using System.Text.Json;
using GeoVision.Application.Configurations;
using GeoVision.Application.DTOs.Eonet;
using GeoVision.Application.Interfaces.External;
using GeoVision.Infrastructure.Integrations.Eonet.Models;
using Microsoft.Extensions.Options;

namespace GeoVision.Infrastructure.Integrations.Eonet;

public class EonetService : IEonetService
{
    private readonly HttpClient _httpClient;

    public EonetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EventDto>> GetEventsAsync(
        string? category = null,
        int? days = null,
        int? limit = null,
        int pageNumber = 1,  
        int pageSize = 10)   
    {
        var query = new List<string>();

        if (!string.IsNullOrWhiteSpace(category))
            query.Add($"category={category}");

        if (days.HasValue)
            query.Add($"days={days.Value}");

        if (limit.HasValue)
            query.Add($"limit={limit.Value}");

        var url = "events";

        if (query.Any())
            url += "?" + string.Join("&", query);

        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<EonetResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (result == null)
            return [];

        return result.Events.Select(e => new EventDto
        {
            Id = e.Id,
            Title = e.Title,
            Category = e.Categories.FirstOrDefault()?.Title ?? "Unknown",
            Date = e.Geometry.FirstOrDefault()?.Date ?? DateTime.MinValue,
            Longitude = e.Geometry.FirstOrDefault()?.Coordinates.FirstOrDefault() ?? 0,
            Latitude = e.Geometry.FirstOrDefault()?.Coordinates.Skip(1).FirstOrDefault() ?? 0
        })
        .Skip((pageNumber - 1) * pageSize) 
        .Take(pageSize)                    
        .ToList();
    }
}