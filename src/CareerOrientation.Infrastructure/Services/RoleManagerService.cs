using CareerOrientation.Application.Auth.Commands.Register;
using CareerOrientation.Application.Common.Abstractions.Services;
using CareerOrientation.Application.Common.Logging;
using CareerOrientation.Domain.Common;
using CareerOrientation.Domain.Entities;

using ErrorOr;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CareerOrientation.Infrastructure.Services;

public class RoleManagerService : IRoleManagerService
{
    private readonly ILogger<RoleManagerService> _logger;
    private readonly UserManager<User> _userManager;

    public RoleManagerService(ILogger<RoleManagerService> logger, UserManager<User> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    /// <inheritdoc/>
    public async Task<ErrorOr<string>> AddUserToRole(RegisterUserCommand registerUserCommand, User newUser)
    {
        string role;

        if (registerUserCommand.IsGraduate)
        {
            role = AppRoles.GraduateStudent;
        }
        else if (registerUserCommand.IsProspectiveStudent)
        {
            role = AppRoles.ProspectiveStudent;
        }
        else
        {
            role = AppRoles.Student;
        }

        var result = await _userManager.AddToRoleAsync(newUser, role);

        if (result.Succeeded)
        {
            return role;
        }

        var errors = result.Errors
            .Select(identityError => Error.Failure(
                    code: identityError.Code,
                    description: identityError.Description
                ))
            .ToList();
        
        _logger.LogFailedRoleAssignment(role);

        return errors;
    }
}
