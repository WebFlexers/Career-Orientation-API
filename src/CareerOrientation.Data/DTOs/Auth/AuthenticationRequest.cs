using System.ComponentModel.DataAnnotations;

namespace CareerOrientation.Data.DTOs.Auth;

public class AuthenticationRequest
{
    [Required]
    public string UsernameOrEmail { get; set; }
    [Required]
    public string Password { get; set; }
}
