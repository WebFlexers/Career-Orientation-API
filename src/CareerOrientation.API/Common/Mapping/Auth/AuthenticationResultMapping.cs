using CareerOrientation.API.Common.Contracts.Auth;
using CareerOrientation.Application.Auth.Common;

namespace CareerOrientation.API.Common.Mapping.Auth;

public static class AuthenticationResultMapping
{
    public static AuthenticationResponse MapToAuthenticationResponse(
        this AuthenticationResult result)
    {
        return new AuthenticationResponse
        (
            UserId: result.UserId,
            Token: result.Token,
            Expiration: result.Expiration
        );
    }
}