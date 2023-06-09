using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Data.Entities.Users;

public class User : IdentityUser
{
    public bool IsProspectiveStudent { get; set; }

    public UniversityStudent? UniversityStudent { get; set; }
}
