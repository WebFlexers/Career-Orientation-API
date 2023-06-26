using CareerOrientation.Data.DTOs.Courses;
using CareerOrientation.Services.Mediator.Queries.Courses;
using CareerOrientation.Services.Validation.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers
{
    /// <summary>
    /// Used for interacting with Courses and their skills
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
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
        /// } <br/>
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CoursesSkillsRequest request, CancellationToken token)
        {
            var result = await _mediator.Send(new GetCoursesWithSkillsQuery(request), token);

            return result.Match<IActionResult>(courseDto =>
                    Ok(courseDto),
            ex =>
                {
                    var response = ex.MapToResponse();
                    return BadRequest(response);
                });
        }
    }
}
