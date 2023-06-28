namespace CareerOrientation.API.Common.Contracts.Auth;

public record AuthenticationRequest(
    string? Username,
    string? Email,
    string Password);