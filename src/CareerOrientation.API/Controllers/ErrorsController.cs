using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

/// <summary>
/// Catches unhandled errors and displays them formatted to the client
/// </summary>
[Route("api/[controller]")]
public class ErrorsController : ControllerBase
{
    internal IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem();
    }
}