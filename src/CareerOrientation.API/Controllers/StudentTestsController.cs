using CareerOrientation.API.Common.Contracts.StudentTests;
using CareerOrientation.API.Common.Mapping.StudentTests;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentTestsController : ApiController
{
    private readonly IMediator _mediator;

    public StudentTestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] StudentTestsQuestionsRequest request, 
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.MapToQuery(), cancellationToken);

        return result.Match(
            result => Ok(result.ConvertAll(test => test.MapToResponse())),
            errors => Problem(errors));
    }
    
}