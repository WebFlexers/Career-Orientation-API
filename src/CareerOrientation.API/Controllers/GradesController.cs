using CareerOrientation.Application.Grades.Queries;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradesController : ApiController
{
    private readonly IMediator _mediator;

    public GradesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Gets the grades of all the courses of the logged in student
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId == null)
        {
            return Problem(statusCode: 401, title: "Unauthorized");
        }
        
        var query = new FetchStudentGradesQuery(userId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(grades => Ok(grades),
            errors => Problem(errors));
    }
}