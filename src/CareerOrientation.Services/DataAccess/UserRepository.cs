using CareerOrientation.Data;
using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.DataAccess.Abstractions;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Services.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public UserRepository(ApplicationDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    ///<inheritdoc/>
    public async Task<Result<UserResponse>> GetUserById(string userId, CancellationToken token)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                var exception = new Exception("User Id not found");
                return new Result<UserResponse>(exception);
            }
        
            if (user.IsProspectiveStudent)
            {
                return new UserResponse(user.UserName!, user.Email!, user.IsProspectiveStudent, false, null, null);
            }

            if (token.IsCancellationRequested)
            {
                return new Result<UserResponse>(new OperationCanceledException("Fetching user cancelled"));
            }

            var student = await _dbContext.UniversityStudents
                .Include(student => student.Track)
                .FirstOrDefaultAsync(student => student.UserId == userId, token);

            if (student is null)
            {
                var exception = new Exception("Student was not found");
                return new Result<UserResponse>(exception);
            }

            if (student.IsGraduate)
            {
                return new UserResponse(user.UserName!, user.Email!, false, true, null, student.Track?.Name);
            }

            return new UserResponse(user.UserName!, user.Email!, false, false, student.Semester, student.Track?.Name);
        }
        catch (Exception ex)
        {
            return new Result<UserResponse>(ex);
        }
    }
}
