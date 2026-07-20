using GeoVision.Application.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace GeoVision.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentWeather([FromQuery] string city)
    {
        var result = await _weatherService.GetCurrentWeatherAsync(city);

        return Ok(result);
    }
}