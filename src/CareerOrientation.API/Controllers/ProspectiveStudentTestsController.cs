using CareerOrientation.API.Common.Mapping.ProspectiveStudentTests;
using CareerOrientation.Application.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsQuestions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProspectiveStudentTestsController : ApiController
{
    private readonly IMediator _mediator;

    public ProspectiveStudentTestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets the questions and answers of the general test whose id was provided
    /// </summary>
    /// <remarks>
    /// The available ids are 2:
    /// * 1 -> ComputerScienceSuitability
    /// * 2 -> UniversityOfPiraeusSuitability
    /// </remarks>
    [HttpGet("generalTestId")]
    public async Task<IActionResult> Get(int generalTestId, CancellationToken cancellationToken)
    {
        var query = new GetProspectiveStudentTestsQuestionsQuery(generalTestId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(test => Ok(test.MapToResponse()),
            errors => Problem(errors));
    }
}