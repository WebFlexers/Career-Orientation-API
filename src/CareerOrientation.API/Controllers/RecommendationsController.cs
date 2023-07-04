using CareerOrientation.Application.Recommendations.Queries.ProspectiveStudentRecommendation;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecommendationsController : ApiController
{
    private readonly IMediator _mediator;

    public RecommendationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Gets the recommendations for the logged in prospective user
    /// </summary>
    /// <remarks>
    /// The algorithm first gives a percentage of how well fitted is informatics as a field for the user based on
    /// the first test. If the percentage is above 50% it means that it is deemed as fitted and it continues to
    /// calculate how well fitted is University of Piraeus for them based on the second test. <br/>
    /// <br/>
    /// Note: To get the recommendations the user must complete all the required tests. If they fail the first test
    /// they can get them immediately. If they succeed they need to complete the second test as well to get them. <br/>
    /// <br/>
    /// </remarks>
    [HttpGet("ProspectiveStudent")]
    [Authorize]
    public async Task<IActionResult> GetProspectiveStudentRecommendation(CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId is null)
        {
            return Problem(statusCode: 401, title: "Unauthorized");
        }

        var query = new ProspectiveStudentRecommendationQuery(userId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(recommendations => Ok(recommendations),
            errors => Problem(errors));
    }
}