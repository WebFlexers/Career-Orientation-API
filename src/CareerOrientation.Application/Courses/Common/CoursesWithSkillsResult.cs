namespace CareerOrientation.Application.Courses.Common;

public record CoursesWithSkillsResult(
    string Name,
    string Description,
    string? Track,
    List<SkillResult> Skills);