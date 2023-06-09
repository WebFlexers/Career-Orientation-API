using CareerOrientation.Data.Entities.Specialties;

namespace CareerOrientation.Data.Entities.Users;

public class UniversityStudent
{
    public string UserId { get; set; }
    public int Semester { get; set; }

    public int? TrackId { get; set; }
    public User User {  get;set; }
    public Track? Track { get; set; }
}
