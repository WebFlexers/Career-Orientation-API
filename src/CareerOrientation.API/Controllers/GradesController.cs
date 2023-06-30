using System.Net;

using CareerOrientation.API.Common.Contracts.Grades;
using CareerOrientation.Application.Grades.Queries;

using MediatR;

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
    
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId == null)
        {
            return Problem();
        }
        
        var query = new FetchStudentGradesQuery(userId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(grades => Ok(grades),
            errors => Problem(errors));
    }
}