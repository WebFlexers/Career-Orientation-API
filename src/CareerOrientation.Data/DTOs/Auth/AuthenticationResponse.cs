namespace CareerOrientation.Data.DTOs.Auth;

public class AuthenticationResponse
{
    public string? UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
