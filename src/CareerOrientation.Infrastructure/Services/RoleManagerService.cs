using CareerOrientation.Application.Auth.Commands.Register;
using CareerOrientation.Application.Common.Abstractions.Services;
using CareerOrientation.Domain.Common;
using CareerOrientation.Domain.Entities;

using ErrorOr;

using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Infrastructure.Services;

public class RoleManagerService : IRoleManagerService
{
    private readonly UserManager<User> _userManager;

    public RoleManagerService(UserManager<User> userManager)
    {
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

        return errors;
    }
}
