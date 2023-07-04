using CareerOrientation.API.Common.Contracts.Tests.Common;
using CareerOrientation.API.Common.Contracts.Tests.ProspectiveStudentTests;
using CareerOrientation.API.Common.Mapping.Tests.ProspectiveStudentTests;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.HasProspectiveStudentTakenTest;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.ProspectiveStudentTestsCompletionState;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.ProspectiveStudentTestsQuestions;

using MediatR;

using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> Get(int generalTestId, CancellationToken cancellationToken)
    {
        var query = new ProspectiveStudentTestsQuestionsQuery(generalTestId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(test => Ok(test.MapToResponse()),
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Gets a bool that indicates whether the logged in user has completed the supplied general test
    /// </summary>
    [HttpGet("Completed/{generalTestId}")]
    [Authorize]
    public async Task<IActionResult> GetCompleted(int generalTestId, CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId is null)
        {
            return Problem(statusCode: 401, title: "Unauthorized");
        }

        var query = new HasProspectiveStudentTakenTestQuery(userId, generalTestId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(
            hasUserTakenTest => Ok(hasUserTakenTest),
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Gets the completion state of all the eligible tests of the logged in user
    /// </summary>
    [HttpGet("Completed")]
    [Authorize]
    public async Task<IActionResult> GetAllCompleted(CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId is null)
        {
            return Problem(statusCode: 401, title: "Unauthorized");
        }

        var query = new ProspectiveStudentTestsCompletionStateQuery(userId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(completedTests =>
            {
                return Ok(new ProspectiveStudentCompletedTestsResponse(
                    HasCompletedAllEssentialTests: completedTests.All(test => test.IsCompleted) && completedTests.Any(),
                    completedTests));
            },
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Submits the test answers of the prospective student
    /// </summary>
    /// <remarks>
    /// Rules: <br/>
    /// * In each question only one type of answer must be specified (either trueFalseAnswer, or multipleChoiceAnswerId 
    /// or likertScaleAnswer) <br/>
    /// * LikertScaleAnswers must be an integer from 1 to 5 <br/>
    /// * All questions of the given test must have an answer <br/> <br/>
    /// </remarks>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] ProspectiveStudentTestsSubmissionRequest request, 
        CancellationToken cancellationToken)
    {
        var command = request.MapToCommand();
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match(
            areAllTestsCompleted => Ok(new TestsSubmissionResponse(areAllTestsCompleted)),
            errors => Problem(errors));
    }
}