using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.TestsUsersRelations;

public class StudentTookUniversityTest
{
    public int UniversityTestId { get; set; }
    public string UserId { get; set; }

    public UniversityTest UniversityTest { get; set; }
    public User User { get; set; }
}
