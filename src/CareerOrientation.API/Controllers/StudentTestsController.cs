using CareerOrientation.API.Common.Contracts.Tests.Common;
using CareerOrientation.API.Common.Contracts.Tests.StudentTests;
using CareerOrientation.API.Common.Mapping.Tests.StudentTests;
using CareerOrientation.Application.Tests.StudentTests.Queries.GetHasStudentTakenTest;
using CareerOrientation.Application.Tests.StudentTests.Queries.GetStudentTestsCompletionState;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> Get([FromQuery] StudentTestQuestionsRequest request, 
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.MapToQuery(), cancellationToken);

        return result.Match(
            result => Ok(result.MapToResponse()),
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Gets a bool that indicates whether the logged in user has completed the supplied university test
    /// </summary>
    [HttpGet("Completed/{universityTestId}")]
    [Authorize]
    public async Task<IActionResult> GetCompleted(int universityTestId, CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId is null)
        {
            return Problem(statusCode: 401, title: "Unauthorized");
        }

        var query = new GetHasStudentTakenTestQuery(userId, universityTestId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(hasUserTakenTest => Ok(hasUserTakenTest),
            errors => Problem(errors));
    }
    
    /// <summary>
    /// Gets the completion state of all the eligible tests of the logged in student
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

        var query = new GetStudentTestsCompletionStateQuery(userId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(completedTests =>
            {
                return Ok(new StudentCompletedTestsResponse(
                    HasCompletedAllTests: completedTests.Any() && completedTests.All(test => test.IsCompleted),
                    completedTests));
            },
            errors => Problem(errors));
    }

    /// <summary>
    /// Submits the test answers of the student
    /// </summary>
    /// <remarks>
    /// Rules: <br/>
    /// * In each question only one type of answer must be specified (either trueFalseAnswer, or multipleChoiceAnswerId 
    /// or likertScaleAnswer) <br/>
    /// * LikertScaleAnswers must be an integer from 1 to 5 <br/>
    /// * All questions of the given test must have an answer <br/> <br/>
    /// Example request <br/>
    /// { <br/>
    ///     "userId": "f1bb4324-1a7c-4e49-987f-aa35e4e6f795", <br/>
    ///     "universityTestId": 1, <br/>
    ///     "answers": [ <br/>
    ///     { <br/>
    ///         "questionId": 21, <br/>
    ///         "multipleChoiceAnswerId": 2 <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "questionId": 22, <br/>
    ///         "trueOrFalseAnswer": true <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "questionId": 23, <br/>
    ///         "likertScaleAnswer": 5 <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "questionId": 24, <br/>
    ///         "multipleChoiceAnswerId": 4 <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "questionId": 25, <br/>
    ///         "trueOrFalseAnswer": false <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "questionId": 26, <br/>
    ///         "likertScaleAnswer": 4 <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "questionId": 27, <br/>
    ///         "multipleChoiceAnswerId": 7 <br/>
    ///     } <br/>
    ///     ] <br/>
    /// }
    /// </remarks>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] StudentTestSubmissionRequest request, 
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.MapToCommand(), cancellationToken);

        return result.Match(
            areAllTestsCompleted => Ok(new TestsSubmissionResponse(areAllTestsCompleted)),
            errors => Problem(errors));
    }
}