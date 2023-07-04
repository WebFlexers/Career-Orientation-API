using CareerOrientation.Application.Courses.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Courses.Queries.CoursesWithSkillsQuery;

public record CoursesWithSkillsQuery(
    int Semester,
    string? Track,
    bool IsProspectiveStudent) : IRequest<ErrorOr<List<CoursesWithSkillsResult>>>;