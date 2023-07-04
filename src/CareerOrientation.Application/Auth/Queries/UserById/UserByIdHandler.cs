using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Entities;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Application.Auth.Queries.UserById;

public class UserByIdHandler : IRequestHandler<UserByIdQuery, ErrorOr<UserResult>>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;

    public UserByIdHandler(UserManager<User> userManager, 
        IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<UserResult>> Handle(UserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user is null)
        {
            return Errors.User.UserNotFoundById;
        }
        
        if (user.IsProspectiveStudent)
        {
            return new UserResult(user.UserName!, user.Email!, user.IsProspectiveStudent, false, 
                null, null);
        }

        if (cancellationToken.IsCancellationRequested)
        {
            return Error.Unexpected();
        }

        var student = await _userRepository.GetUniversityStudentById(request.UserId);

        if (student is null)
        {
            return Errors.User.UserNotFoundById;
        }

        if (student.IsGraduate)
        {
            return new UserResult(user.UserName!, user.Email!, false, 
                true, null, student.Track?.Name);
        }

        return new UserResult(user.UserName!, user.Email!, false, false, 
            student.Semester, student.Track?.Name);
    }
}