using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class UserCourseGrade
{
    public int CourseId { get; set; }
    public string UserId { get; set; }
    public float Value { get; set; }
    
    public User User { get; set; }
    public Course Course { get; set; }
}
