using CareerOrientation.Domain.JunctionEntities;

namespace CareerOrientation.Domain.Entities;

public class Course
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Semester { get; set; }

    public int? TrackId { get;set; }
    public Track Track { get; set; }

    public List<Skill> Skills { get; set; }

    public List<UserCourseGrade> UserCourseGrades { get; set; }
    public List<UserCourseStatistics> UserCourseStatistics { get; set; }
}
