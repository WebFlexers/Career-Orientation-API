using System.ComponentModel.DataAnnotations;

namespace CareerOrientation.Data.DTOs.Auth;

public class AuthenticationRequest
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
}
