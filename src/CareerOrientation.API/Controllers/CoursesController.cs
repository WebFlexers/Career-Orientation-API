using CareerOrientation.Data.DTOs.Courses;
using CareerOrientation.Services.Mediator.Queries.Courses;
using CareerOrientation.Services.Validation.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers
{
    /// <summary>
    /// Used for interacting with Courses
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
