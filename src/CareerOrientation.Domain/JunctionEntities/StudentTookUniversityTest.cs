using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class StudentTookUniversityTest
{
    public int UniversityTestId { get; set; }
    public string UserId { get; set; }

    public UniversityTest UniversityTest { get; set; }
    public User User { get; set; }

    public StudentTookUniversityTest(string userId, int universityTestId)
    {
        UserId = userId;
        UniversityTestId = universityTestId;
    }
}
