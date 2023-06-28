using CareerOrientation.Application.Courses.Common;

namespace CareerOrientation.API.Common.Contracts.Courses;

public record GetCoursesWithSkillsResponse(
    string Name,
    string Description,
    string? Track,
    List<SkillResult> Skills);