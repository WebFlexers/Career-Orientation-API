using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;
using LanguageExt.Common;

namespace CareerOrientation.Services.DataAccess.Abstractions;

public interface IUserRepository
{
    /// <summary>
    /// Identifies the user type and creates a UserResponse object  
    /// </summary>
    Task<Result<UserResponse>> GetUserById(string userId, CancellationToken token);

    /// <summary>
    /// Creates a student from the createUserRequest and the userId
    /// </summary>
    Task<Result<UniversityStudent>> CreateStudent(CreateUserRequest createRequest, string userId);
}
