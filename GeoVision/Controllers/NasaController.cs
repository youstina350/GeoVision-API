using GeoVision.Application.Interfaces.External;
using Microsoft.AspNetCore.Mvc;

namespace GeoVision.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NasaController : ControllerBase
{
    private readonly INasaService _nasaService;

    public NasaController(INasaService nasaService)
    {
        _nasaService = nasaService;
    }

    [HttpGet("apod")]
    public async Task<IActionResult> GetAstronomyPicture()
    {
        var result = await _nasaService.GetAstronomyPictureAsync();

        return Ok(result);
    }
}