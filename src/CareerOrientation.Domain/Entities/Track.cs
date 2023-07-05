namespace CareerOrientation.Domain.Entities;

public class Track
{
    public int TrackId { get; init; }
    public string Name { get; set; }

    public List<UniversityStudent> UniversityStudents { get; set; }
    public List<Question> Questions { get; set; }

    public List<Course> Courses { get; set; }

    public List<MastersDegree> MastersDegrees { get; set; }
    public List<Profession> Professions { get; set; }

    public List<UniversityTest> UniversityTests { get;set; }
    
    public override bool Equals(object obj)
    {
        if (obj is not Track otherTrack)
            return false;

        return TrackId == otherTrack.TrackId;
    }

    public override int GetHashCode()
    {
        return TrackId.GetHashCode();
    }
    
}
