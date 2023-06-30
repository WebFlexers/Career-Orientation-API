using CareerOrientation.Application.Grades.Common;

namespace CareerOrientation.API.Common.Contracts.Grades;

public record StudentGradesResponse(
    List<GradeResult> CourseGrades);