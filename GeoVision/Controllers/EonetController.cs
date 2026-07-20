using GeoVision.Application.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace GeoVision.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EonetController : ControllerBase
{
    private readonly IEonetService _eonetService;

    public EonetController(IEonetService eonetService)
    {
        _eonetService = eonetService;
    }

    [HttpGet("events")]
    public async Task<IActionResult> GetEvents(
        [FromQuery] string? category,
        [FromQuery] int? days,
        [FromQuery] int? limit,
        [FromQuery] int pageNumber = 1,  
        [FromQuery] int pageSize = 10)   
    {
        var events = await _eonetService.GetEventsAsync(category, days, limit, pageNumber, pageSize);

        return Ok(events);
    }
}