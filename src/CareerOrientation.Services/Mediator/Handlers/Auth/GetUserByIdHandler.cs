using CareerOrientation.Data.DTOs.Auth;
using CareerOrientation.Services.DataAccess.Abstractions;
using CareerOrientation.Services.Mediator.Queries.Auth;
using LanguageExt.Common;
using MediatR;

namespace CareerOrientation.Services.Mediator.Handlers.Auth;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        return await _userRepository.GetUserById(userId, cancellationToken);
    }
}
