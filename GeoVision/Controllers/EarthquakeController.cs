using GeoVision.Application.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace GeoVision.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EarthquakeController : ControllerBase
{
    private readonly IEarthquakeService _earthquakeService;

    public EarthquakeController(IEarthquakeService earthquakeService)
    {
        _earthquakeService = earthquakeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecentEarthquakes()
    {
        var earthquakes = await _earthquakeService.GetRecentEarthquakesAsync();
        return Ok(earthquakes);
    }
}