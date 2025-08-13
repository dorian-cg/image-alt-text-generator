using Microsoft.AspNetCore.Mvc;

namespace ImageAltTextService.Controllers;

[ApiController]
[Route("api/v1/status")]
public class StatusController : Controller
{
    [HttpGet]
    public IActionResult GetStatus()
    {
        return new OkObjectResult(DateTime.Now.ToString("O"));
    }
}
