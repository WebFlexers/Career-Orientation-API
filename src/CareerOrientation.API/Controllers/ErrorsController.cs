using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

/// <summary>
/// Catches unhandled errors and displays them formatted to the client
/// </summary>
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return exception switch
        {
            OperationCanceledException => Problem(statusCode: 499, title: "Operation Cancelled"),
            _ => Problem()
        };
    }
}