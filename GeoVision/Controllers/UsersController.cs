using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeoVision.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        return Ok(new
        {
            Message = "Welcome! You are authenticated.",
            User = User.Identity?.Name,
            Claims = User.Claims.Select(c => new
            {
                c.Type,
                c.Value
            })
        });
    }
}