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

    /// <summary>
    /// Gets the questions and answers of the test either of the given semester or the revision of a year.
    /// </summary>
    /// <remarks>
    /// Rules: <br/>
    /// 1) Either the semester or the revision year must be specified, not both. <br/> <br/>
    /// 2) The track must be supplied only for: <br/>
    /// * Tests that correspond to semesters from 5 or above <br/>
    /// * Tests that correspond to a revision of a year that is 3 or above
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] StudentTestsQuestionsRequest request, 
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.MapToQuery(), cancellationToken);

        return result.Match(
            result =>
            {
                var tests = result.ConvertAll(test => test.MapToResponse());
                return Ok(tests);
            },
            errors => Problem(errors));
    }
    
}