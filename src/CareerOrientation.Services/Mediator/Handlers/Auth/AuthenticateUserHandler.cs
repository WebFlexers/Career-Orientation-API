using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.Auth.Abstractions;
using CareerOrientation.Services.Common;
using CareerOrientation.Services.Mediator.Queries.Auth;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Authentication;

namespace CareerOrientation.Services.Mediator.Handlers.Auth;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, Result<AuthenticationResponse>>
{
    private readonly ILogger<AuthenticateUserHandler> _logger;
    private readonly ITokenCreationService _tokenCreationService;
    private readonly UserManager<User> _userManager;

    public AuthenticateUserHandler(ILogger<AuthenticateUserHandler> logger, ITokenCreationService tokenCreationService,
        UserManager<User> userManager)
    {
        _logger = logger;
        _tokenCreationService = tokenCreationService;
        _userManager = userManager;
    }

    public async Task<Result<AuthenticationResponse>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
    {
        var authRequest = request.AuthRequest;

        if (authRequest.Username is null && authRequest.Email is null)
        {
            var exception = new ArgumentNullException(authRequest.Username, "Username and email were null");
            _logger.LogNullCredentialsLogin();
            return new Result<AuthenticationResponse>(exception);
        }

        User? user = null;

        if (authRequest.Username is not null)
        {
            user = await _userManager.FindByNameAsync(authRequest.Username);
        }

        if (user is null && authRequest.Email is not null)
        {
            user = await _userManager.FindByEmailAsync(authRequest.Email);
        }

        if (user is null)
        {
            var exception = new AuthenticationException("Ο συνδυασμός ονόματος χρήστη / email και κωδικού πρόσβασης είναι λάθος");
            _logger.LogUserNotFoundOnLogin(authRequest.Username, authRequest.Email);
            return new Result<AuthenticationResponse>(exception);
        }

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, authRequest.Password);

        if (isPasswordCorrect == false)
        {
            var exception = new AuthenticationException("Ο συνδυασμός ονόματος χρήστη / email και κωδικού πρόσβασης είναι λάθος");
            _logger.LogAuthenticationFailed(authRequest.Username, authRequest.Email);
            return new Result<AuthenticationResponse>(exception);
        }

        _logger.LogSuccessfulLogin(authRequest.Username, authRequest.Email);
        return _tokenCreationService.CreateToken(user);
    }
}
