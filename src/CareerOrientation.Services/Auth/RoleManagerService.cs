using CareerOrientation.Data;
using CareerOrientation.Data.DTOs;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.Validation.Exceptions;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Services.Auth;

public class RoleManagerService : IRoleManagerService
{
    private readonly UserManager<User> _userManager;

    public RoleManagerService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    /// <inheritdoc/>
    public async Task<Result<string>> AddUserToRole(CreateUserRequest createUserRequest, User newUser)
    {
        string role;

        if (createUserRequest.IsGraduate)
        {
            role = AppRoles.GraduateStudent;
        }
        else if (createUserRequest.IsProspectiveStudent)
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
        else
        {
            var exception = new IdentityException(result.Errors);
            return new Result<string>(exception);
        }
    }
}
