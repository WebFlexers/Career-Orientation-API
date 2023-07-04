
using CareerOrientation.API.Common.Contracts.Statistics;
using CareerOrientation.Application.Statistics.Commands;
using CareerOrientation.Application.Statistics.Queries.TeachingAccessStats;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ApiController
{
    private readonly IMediator _mediator;

    public StatisticsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Increments the semester or the revision year access count statistic for the logged in user by one
    /// </summary>
    [HttpPost("TeachingAccessStatistics")]
    [Authorize]
    public async Task<IActionResult> PostTeachingAccessStats([FromBody] PostTeachingAccessStatsRequest request, 
        CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId is null)
        {
            return Problem(statusCode: 401, title: "Unauthorized");
        }

        var command = new IncrementTeachingAccessStatCommand(userId, request.Semester);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match(_ => Ok(),
            errors => Problem(errors));
    }
    /// <summary>
    /// Gets all the teaching access statistics for both the semesters and the revision years
    /// </summary>
    [HttpGet("TeachingAccessStatistics")]
    [Authorize]
    public async Task<IActionResult> GetTeachingAccessStats(CancellationToken cancellationToken)
    {
        var userId = GetUserIdFromToken();
        if (userId is null)
        {
            return Problem(statusCode: 401, title: "Unauthorized");
        }

        var query = new TeachingAccessStatsQuery(userId);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match(accessStats => Ok(accessStats),
            errors => Problem(errors));
    }
}