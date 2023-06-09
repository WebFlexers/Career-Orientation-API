using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.Specialties;

public class Track
{
    public int TrackId { get; set; }
    public string Name { get; set; }

    public List<UniversityStudent> UniversityStudents { get; set; }
}
