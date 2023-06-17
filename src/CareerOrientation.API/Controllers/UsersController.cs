using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Services.Mediator.Commands.Auth;
using CareerOrientation.Services.Mediator.Queries.Auth;
using CareerOrientation.Services.Validation.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Users/userId
    [HttpGet("{userId}")]
    [Authorize]
    public async Task<IActionResult> Get([FromRoute] string userId)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(userId));

        return result.Match<IActionResult>(
            userResponse => Ok(userResponse),
            error => BadRequest(error.MapToResponse())
        );
    }

    // POST: api/Users
    /// <summary>
    /// Registers a user to the identity system
    /// </summary>
    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest createUserRequest)
    {
        var result = await _mediator.Send(new CreateUserCommand(createUserRequest));

        return result.Match<IActionResult>(
            authResponse => CreatedAtAction(nameof(Get), new { userId = authResponse.UserId}, authResponse),
            error => BadRequest(error.MapToResponse())
        );
    }

    // POST: api/Users/Login
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request)
    {
        //if (!ModelState.IsValid)
        //{
        //    return Unauthorized("Authentication failed");
        //}

        //User? user;

        //user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

        //if (user == null)
        //{
        //    user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
        //    if (user == null)
        //    {
        //        return Unauthorized("Authentication failed");
        //    }
        //}

        //var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        //if (isPasswordValid == false)
        //{
        //    return Unauthorized("Authentication failed");
        //}

        //var token = _tokenCreationService.CreateToken(user);

        //return Ok(token);
        return Ok();
    }
}
