using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Data.Entities;

public class User : IdentityUser
{
    public bool IsUniStudent { get; set; }
    public int? Semester { get; set; }
    public string? Track { get; set; } // In greek: Κατεύθυνση
}
