using CareerOrientation.API.Common.Contracts.Courses;
using CareerOrientation.API.Common.Mapping.Courses;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ApiController
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Gets the courses of the given semester. For semesters 1-4 track must be null, while for semesters
    /// 5+ it is mandatory.
    /// </summary>
    /// <remarks>
    /// Sample request: GET /api/Courses with query: semester = 1, track = null <br/> <br/>
    /// Sample response: <br/>
    /// { <br/>
    ///     "Name": "A course", <br/>
    ///     "Description": "A course description", <br/>
    ///     "skills": [ <br/>
    ///     { <br/>
    ///         "name": "A hard skill needed", <br/>
    ///         "type": "hard" <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "name": "A soft skill needed", <br/>
    ///         "type": "soft" <br/>
    ///     }] <br/>
    /// }, <br/>
    /// { <br/>
    ///     "Name": "Another course", <br/>
    ///     "Description": "Another course description", <br/>
    ///     "skills": [ <br/>
    ///     { <br/>
    ///         "name": "One hard skill", <br/>
    ///         "type": "hard" <br/>
    ///     }, <br/>
    ///     { <br/>
    ///         "name": "Another soft skill", <br/>
    ///         "type": "soft" <br/>
    ///     }] <br/>
    /// </remarks>
    [HttpGet]
    [AllowAnonymous]
    [ResponseCache(Duration = 60*5, Location = ResponseCacheLocation.Any, NoStore = false, 
        VaryByQueryKeys = new []{
            nameof(GetCoursesWithSkillsRequest.Semester), 
            nameof(GetCoursesWithSkillsRequest.Track), 
            nameof(GetCoursesWithSkillsRequest.IsProspectiveStudent)})]
    public async Task<IActionResult> Get([FromQuery]GetCoursesWithSkillsRequest request, CancellationToken token)
    {
        var result = await _mediator.Send(request.MapToQuery(), token);

        return result.Match<IActionResult>(coursesWithSkillsResults =>
            Ok(coursesWithSkillsResults.ConvertAll(cws => cws.MapToResponse())),
            errors => Problem(errors));
    }
}
