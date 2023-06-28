namespace CareerOrientation.API.Common.Contracts.Courses;

public record GetCoursesWithSkillsRequest(
    int Semester,
    string? Track,
    bool IsProspectiveStudent);