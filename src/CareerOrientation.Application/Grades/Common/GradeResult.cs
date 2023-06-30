namespace CareerOrientation.Application.Grades.Common;

public record GradeResult(
    int CourseId,
    string CourseName,
    double Grade,
    int Semester);