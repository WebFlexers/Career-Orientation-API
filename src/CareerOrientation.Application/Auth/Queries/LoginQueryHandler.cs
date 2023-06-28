using CareerOrientation.Application.Auth.Common;
using ErrorOr;
using MediatR;

namespace CareerOrientation.Application.Auth.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}