using CareerOrientation.API.Common.Contracts.Auth;
using CareerOrientation.API.Common.Mapping.Auth;
using CareerOrientation.Application.Auth.Queries.GetUser;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ApiController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/Users/userId
    /// <summary>
    /// Gets the user with the specified id. Authorization is required
    /// </summary>
    /// <returns>A UserResponse of the specified user or an error message</returns>
    /// <remarks>
    /// Sample request: GET /api/Users/594e238d-5964-4501-8908-36ddf9cba177 <br/> <br/>
    /// Sample response (success): <br/>
    /// { <br/>
    ///   "username": "Whateverer123", <br/>
    ///   "email": "somemail@gmail.com", <br/>
    ///   "isProspectiveStudent": true, <br/>
    ///   "isGraduate": false, <br/>
    ///   "semester": null, <br/>
    ///   "track": null <br/>
    /// } <br/> <br/>
    /// Sample response (error): <br/>
    /// The user with the specified id was not found
    /// </remarks>
    [HttpGet("{userId}")]
    [Authorize]
    public async Task<IActionResult> Get(string userId, CancellationToken token)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(userId), token);

        return result.Match<IActionResult>(
            userResponse => Ok(userResponse),
            errors => Problem(errors));
    }

    // POST: api/Users
    /// <summary>
    /// Registers a user to the identity server.
    /// </summary>
    /// <returns>An AuthorizationResponse or an error message</returns>
    /// <remarks>
    /// Sample request: POST /api/Users/Register <br/>
    /// { <br/>
    ///   "username": "Whatever", <br/>
    ///   "password": "strinG0", <br/>
    ///   "confirmPassword": "strinG0", <br/>
    ///   "email": "jack@gmail.com", <br/>
    ///   "isProspectiveStudent": true, <br/>
    ///   "isGraduate": false, <br/>
    ///   "semester": null, <br/>
    ///   "track": null <br/>
    /// } <br/> <br/>
    /// Sample response (success): <br/>
    /// { <br/>
    ///   "userId": "1f8d4b7a-9f0f-43f9-a62e-9fa0d0e241df", <br/>
    ///   "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKV1QgZm9yIENhcmVlck9yaWVudGF0aW9uQXBpIiwianRpIjoiNTE2NjgwN2MtMDYyMy00NmM3LTliNzItZmIzMjU5ZGE5NDYzIiwiaWF0IjoiMTcvMDYvMjAyMyA3OjU5OjMyIHBtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiIxZjhkNGI3YS05ZjBmLTQzZjktYTYyZS05ZmEwZDBlMjQxZGYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiV2hhdGV2ZXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJiYXN0YXJkQGdtYWlsLmNvbSIsIm5iZiI6MTY4NzAzMTk3MiwiZXhwIjoxNjg3NjM2NzcyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTU1IiwiYXVkIjoiQ2FyZWVyT3JpZW50YXRpb25BcGkifQ.HHc7sbmG3eDgycq1clpzIu7BKXhZV898TCOW0YGQ1B0", <br/>
    ///   "expiration": "2023-06-24T19:59:32.7918889Z" <br/>
    /// } <br/> <br/>
    /// Sample response (error): <br/>
    /// [ <br/>
    ///   { <br/>
    ///     "code": "DuplicateUserName", <br/>
    ///     "description": "Το όνομα χρήστη 'Whatever' χρησιμοποιείται ήδη." <br/>
    ///   }, <br/>
    ///   { <br/> 
    ///     "code": "DuplicateEmail", <br/>
    ///     "description": "Το email 'jack@gmail.com' χρησιμοποιείται ήδη." <br/>
    ///   } <br/>
    /// ] <br/>
    /// </remarks>
    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest createUserRequest)
    {
        var registerCommand = createUserRequest.MapToRegisterUserCommand();
        var result = await _mediator.Send(registerCommand);

        return result.Match<IActionResult>(
            authResponse =>
                CreatedAtAction(nameof(Get), new { userId = authResponse.UserId }, authResponse),
            errors => Problem(errors));
    }

    // POST: api/Users/Login
    /// <summary>
    /// Authenticates the user.
    /// </summary>
    /// <returns>
    /// An AuthenticationRequest or an error message
    /// </returns>
    /// <remarks>
    /// Sample Request: POST /api/Users/Login <br/>
    /// { <br/>
    ///   "username": "Whatever", <br/>
    ///   "email": null, <br/>
    ///   "password": "strinG0" <br/>
    /// } <br/> <br/>
    /// Sample Response (success): <br/>
    /// Same as Register <br/> <br/>
    /// Sample Response (error): <br/>
    /// Authentication Failed - Invalid username or password
    /// </remarks>
    /// <returns></returns>
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest request, CancellationToken token)
    {
        var result = await _mediator.Send(request.MapToLoginQuery(), token);

        return result.Match<IActionResult>(
            authResponse => Ok(authResponse),
            errors => Problem(statusCode: 401, title: errors[0].Description));
    }
}