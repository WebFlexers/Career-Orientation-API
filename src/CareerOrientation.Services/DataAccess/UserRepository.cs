using CareerOrientation.Data;
using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.Common;
using CareerOrientation.Services.DataAccess.Abstractions;
using LanguageExt.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CareerOrientation.Services.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public UserRepository(ILogger<UserRepository> logger, ApplicationDbContext dbContext, UserManager<User> userManager)
    {
        _logger = logger;
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
                var exception = new Exception("Δεν βρέθηκε χρήστης με το δεδομένο ID");
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
                var exception = new Exception("Δεν βρέθηκε χρήστης με το δεδομένο ID");
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

    ///<inheritdoc/>
    public async Task<Result<UniversityStudent>> CreateStudent(CreateUserRequest createRequest, string userId)
    {
        try
        {
            var track = await _dbContext.Tracks.FirstOrDefaultAsync(track => track.Name == createRequest.Track);
            
            var student = new UniversityStudent()
            {
                UserId = userId,
                IsGraduate = createRequest.IsGraduate,
                Semester = createRequest.Semester,
                TrackId =  track?.TrackId
            };

            await _dbContext.UniversityStudents.AddAsync(student);

            await _dbContext.SaveChangesAsync();

            _logger.LogSuccessfullStudentInsertion(userId);

            return student;
        }
        catch (Exception ex)
        {
            return new Result<UniversityStudent>(ex);
        }
    }
}
