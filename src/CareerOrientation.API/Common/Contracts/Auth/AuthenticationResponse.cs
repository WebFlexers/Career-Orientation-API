namespace CareerOrientation.API.Common.Contracts.Auth;

public record AuthenticationResponse(
    string UserId,
    string Token,
    DateTime Expiration);