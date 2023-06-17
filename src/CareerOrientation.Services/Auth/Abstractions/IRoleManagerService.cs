using CareerOrientation.Data.DTOs;
using CareerOrientation.Data.Entities.Users;
using LanguageExt.Common;

namespace CareerOrientation.Services.Auth;

public interface IRoleManagerService
{
    /// <summary>
    /// Calculates the correct role for the user and assigns it
    /// </summary>
    /// <returns>The role assigned if successful</returns>
    Task<Result<string>> AddUserToRole(CreateUserRequest createUserRequest, User newUser);
}