using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Grades.Common;

public static class CourseMapping
{
    /// <summary>
    /// Maps the course to a grade result, with randomly generated grades
    /// </summary>
    public static GradeResult MapToGradeResult(this Course course, Random random)
    {
        return new GradeResult(
            CourseId: course.CourseId,
            CourseName: course.Name,
            Grade: GenerateRandomFloat(4, 10, random),
            Semester: course.Semester);
    }
    
    private static float GenerateRandomFloat(int min, int max, Random random)
    {
        return (float)Math.Round(random.NextDouble() * (max - min) + min);
    }
}