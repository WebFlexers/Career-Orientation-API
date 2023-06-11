using CareerOrientation.Data.Entities.Courses;
using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.Specialties;

public class Track
{
    public int TrackId { get; set; }
    public string Name { get; set; }

    public List<UniversityStudent>? UniversityStudents { get; set; }
    public List<Question>? Questions { get; set; }

    public List<Course>? Courses { get; set; }

    public List<MastersDegree> MastersDegrees { get; set; }
    public List<Profession> Professions { get; set; }

    public List<UniversityTest> UniversityTests { get;set; }
}
