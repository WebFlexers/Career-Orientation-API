namespace CareerOrientation.Application.Auth.Common;

public record AuthenticationResult(
    string UserId,
    string Token,
    DateTime Expiration
);