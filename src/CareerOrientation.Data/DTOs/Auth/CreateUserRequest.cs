using System.ComponentModel.DataAnnotations;

namespace CareerOrientation.Data.DTOs.Auth;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
    public bool IsProspectiveStudent { get; set; }
    public bool IsGraduate { get; set; }
    public int? Semester { get; set; }
    public string? Track { get; set; }
}
