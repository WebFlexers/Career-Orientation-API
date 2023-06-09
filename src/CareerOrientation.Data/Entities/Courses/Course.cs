using CareerOrientation.Data.Entities.UsersCoursesRelations;

namespace CareerOrientation.Data.Entities.Courses;

public class Course
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Semester { get; set; }

    public List<Skill>? Skills { get; set; }

    public List<UserCourseGrade> UserCourseGrades { get; set; }
    public List<UserCourseStatistics> UserCourseStatistics { get; set; }
}
