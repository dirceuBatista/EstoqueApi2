using EstoqueApi.Attribuites;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers;

[ApiController]

[Route("")]
public class HomeController : ControllerBase
{[HttpGet("")]
    public IActionResult Get()
    {
        return Ok();
    }
}