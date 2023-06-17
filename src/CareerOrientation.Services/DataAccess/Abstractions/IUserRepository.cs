using CareerOrientation.Data.DTOs.Auth;
using LanguageExt.Common;

namespace CareerOrientation.Services.DataAccess.Abstractions;

public interface IUserRepository
{
    /// <summary>
    /// Identifies the user type and creates a UserResponse object  
    /// </summary>
    Task<Result<UserResponse>> GetUserById(string userId, CancellationToken token);
}
