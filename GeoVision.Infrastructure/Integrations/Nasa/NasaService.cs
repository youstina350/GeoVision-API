using System.Net.Http.Json;
using GeoVision.Application.Configurations;
using GeoVision.Application.DTOs.Nasa;
using GeoVision.Application.Exceptions;
using GeoVision.Application.Interfaces.External;
using GeoVision.Infrastructure.Integrations.Nasa.Models;
using Microsoft.Extensions.Options;

namespace GeoVision.Infrastructure.Integrations.Nasa;

public class NasaService : INasaService
{
    private readonly HttpClient _httpClient;
    private readonly NasaApiOptions _options;

    public NasaService(
        HttpClient httpClient,
        IOptions<NasaApiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<ApodDto> GetAstronomyPictureAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<NasaApodResponse>(
            $"apod?api_key={_options.ApiKey}");

        if (response is null)
        {
            throw new NotFoundException("NASA data not found.");
        }

        return new ApodDto
        {
            Title = response.Title,
            Explanation = response.Explanation,
            ImageUrl = response.Url,
            Date = response.Date
        };
    }
}