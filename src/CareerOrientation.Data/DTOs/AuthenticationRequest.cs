using System.ComponentModel.DataAnnotations;

namespace CareerOrientation.Data.DTOs;

public class AuthenticationRequest
{
    [Required]
    public string UsernameOrEmail { get; set; }
    [Required]
    public string Password { get; set; }
}
