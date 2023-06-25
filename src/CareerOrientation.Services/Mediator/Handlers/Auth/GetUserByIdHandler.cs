using CareerOrientation.Data;
using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Services.Mediator.Queries.Auth;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Services.Mediator.Handlers.Auth;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public GetUserByIdHandler(ApplicationDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        
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

            if (cancellationToken.IsCancellationRequested)
            {
                return new Result<UserResponse>(new OperationCanceledException("Fetching user cancelled"));
            }

            var student = await _dbContext.UniversityStudents
                .Include(student => student.Track)
                .FirstOrDefaultAsync(student => student.UserId == userId, cancellationToken);

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
}
