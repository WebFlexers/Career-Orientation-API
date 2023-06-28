using CareerOrientation.Application.Courses.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Courses.Queries.GetCoursesWithSkillsQuery;

public record GetCoursesWithSkillsQuery(
    int Semester,
    string? Track,
    bool IsProspectiveStudent) : IRequest<ErrorOr<List<CoursesWithSkillsResult>>>;