namespace CareerOrientation.Domain.Entities;

public class UniversityTest
{
    public int UniversityTestId { get; set; }
    public int? Semester { get; set; }
    public int Year { get; set; }
    public bool IsRevision { get; set; }

    public int? TrackId { get; set; }
    public Track? Track { get; set; }

    public List<Question> Questions { get; set; }
    public List<User>? UsersTookTest { get; set; }
}
