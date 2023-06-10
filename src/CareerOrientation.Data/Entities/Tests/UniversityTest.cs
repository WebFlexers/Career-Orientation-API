using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.Tests;

// TODO: Create migration for int? change
public class UniversityTest
{
    public int UniversityTestId { get; set; }
    public int? Semester { get; set; }
    public int Year { get; set; }
    public bool IsRevision { get; set; }

    public List<Question> Questions { get; set; }
    public List<User>? UsersTookTest { get; set; }
}
