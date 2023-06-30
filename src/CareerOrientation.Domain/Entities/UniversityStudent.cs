using CareerOrientation.Domain.JunctionEntities;

namespace CareerOrientation.Domain.Entities;

public class UniversityStudent
{
    public string UserId { get; set; }
    public int? Semester { get; set; }
    public bool IsGraduate { get; set; }

    public int? TrackId { get; set; }
    public User User {  get;set; }
    public Track? Track { get; set; }
}
