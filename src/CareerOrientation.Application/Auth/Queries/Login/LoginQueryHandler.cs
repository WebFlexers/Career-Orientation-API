using CareerOrientation.Application.Auth.Common;
using CareerOrientation.Application.Common.Abstractions.Auth;
using CareerOrientation.Application.Common.Logging;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Entities;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CareerOrientation.Application.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly ILogger<LoginQueryHandler> _logger;
    private readonly UserManager<User> _userManager;
    private readonly ITokenCreationService _tokenCreationService;

    public LoginQueryHandler(ILogger<LoginQueryHandler> logger, UserManager<User> userManager,
        ITokenCreationService tokenCreationService)
    {
        _logger = logger;
        _userManager = userManager;
        _tokenCreationService = tokenCreationService;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (request.Username is null && request.Email is null)
        {
            return Errors.Auth.NullCredentials;
        }

        User? user = null;

        if (request.Username is not null)
        {
            user = await _userManager.FindByNameAsync(request.Username);
        }

        if (user is null && request.Email is not null)
        {
            user = await _userManager.FindByEmailAsync(request.Email);
        }

        if (user is null)
        {
            _logger.LogAuthenticationFailed(request.Username, request.Email);
            return Errors.Auth.AuthFailure;
        }

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);

        if (isPasswordCorrect == false)
        {
            _logger.LogAuthenticationFailed(request.Username, request.Email);
            return Errors.Auth.AuthFailure;
        }

        _logger.LogSuccessfulLogin(request.Username, request.Email);
        return _tokenCreationService.CreateToken(user);
    }
}