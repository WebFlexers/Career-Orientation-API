using CareerOrientation.API.Common.Contracts.Auth;
using CareerOrientation.Application.Auth.Queries.Login;

namespace CareerOrientation.API.Common.Mapping.Auth;

public static class AuthenticationRequestMapping
{
    public static LoginQuery MapToLoginQuery(this AuthenticationRequest request)
    {
        return new LoginQuery(
            Username: request.Username,
            Email: request.Email,
            Password: request.Password);
    }
}