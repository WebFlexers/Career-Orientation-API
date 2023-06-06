using System.ComponentModel.DataAnnotations;

namespace CareerOrientation.Data.DTOs;

public class UserDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public bool IsUniStudent { get; set; }

    public int? Semester { get; set; }

    public string? Track { get; set; }
}
