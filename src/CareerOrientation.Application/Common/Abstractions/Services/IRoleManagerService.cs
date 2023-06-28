using CareerOrientation.Application.Auth.Commands.Register;
using CareerOrientation.Domain.Entities;

using ErrorOr;

namespace CareerOrientation.Application.Common.Abstractions.Services;

public interface IRoleManagerService
{
    /// <summary>
    /// Calculates the correct role for the user and assigns it
    /// </summary>
    /// <returns>The role assigned if successful</returns>
    Task<ErrorOr<string>> AddUserToRole(RegisterUserCommand registerUserCommand, User newUser);
}