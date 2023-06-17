using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;

namespace CareerOrientation.Data.Entities.Users;

public class UniversityStudent
{
    public string UserId { get; set; }
    public int? Semester { get; set; }
    public bool IsGraduate { get; set; }

    public int? TrackId { get; set; }
    public User User {  get;set; }
    public Track? Track { get; set; }
}
