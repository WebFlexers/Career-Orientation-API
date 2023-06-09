using CareerOrientation.Data.DTOs;
using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.Auth.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CareerOrientation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly ITokenCreationService _tokenCreationService;

    public UsersController(ILogger<UsersController> logger, UserManager<User> userManager, 
        ITokenCreationService tokenCreationService)
    {
        _logger = logger;
        _userManager = userManager;
        _tokenCreationService = tokenCreationService;
    }

    // GET: api/Users/username
    [HttpGet("{username}")]
    public async Task<ActionResult<UserDTO>> GetUser(string username)
    {
        //User? user = await _userManager.FindByNameAsync(username);

        //if (user == null)
        //{
        //    return NotFound();
        //}

        //return new UserDTO
        //{
        //    Username = user.UserName,
        //    Email = user.Email,
        //    IsUniStudent = user.IsUniStudent,
        //    Semester = user.Semester,
        //    Track = user.Track
        //};
        return Ok();
    }

    // POST: api/Users
    /// <summary>
    /// Registers a user to the identity system
    /// </summary>
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<UserDTO>> PostUser(UserDTO user)
    {
        //// TODO: Validate the given information further
        //if (ModelState.IsValid == false)
        //{
        //    return BadRequest(ModelState);
        //}

        //var result = await _userManager.CreateAsync(
        //    new User() { 
        //        UserName = user.Username, 
        //        Email = user.Email,
        //        IsUniStudent = user.IsUniStudent,
        //        Semester = user.Semester,
        //        Track = user.Track
        //    },
        //    user.Password
        //);

        //if (result.Succeeded == false)
        //{
        //    return BadRequest(result.Errors);
        //}

        //user.Password = null;
        //_logger.LogInformation("User created: {user}", user.Username);
        //return CreatedAtAction(nameof(GetUser), new { username = user.Username }, user);
        return Ok();
    }

    // POST: api/Users/Login
    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Unauthorized("Authentication failed");
        }

        User? user;

        user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            if (user == null)
            {
                return Unauthorized("Authentication failed");
            }
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (isPasswordValid == false)
        {
            return Unauthorized("Authentication failed");
        }

        var token = _tokenCreationService.CreateToken(user);

        return Ok(token);
    }
}
