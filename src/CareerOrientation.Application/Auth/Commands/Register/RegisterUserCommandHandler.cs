using CareerOrientation.Application.Auth.Common;
using ErrorOr;
using MediatR;

namespace CareerOrientation.Application.Auth.Commands.Register;

public class RegisterUserCommandHandler :
    IRequestHandler<RegisterUserCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterUserCommand userCommand, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}