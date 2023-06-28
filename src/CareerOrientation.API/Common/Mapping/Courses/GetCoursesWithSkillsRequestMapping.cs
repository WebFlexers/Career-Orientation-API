using CareerOrientation.API.Common.Contracts.Courses;
using CareerOrientation.Application.Courses.Queries.GetCoursesWithSkillsQuery;

namespace CareerOrientation.API.Common.Mapping.Courses;

public static class GetCoursesWithSkillsRequestMapping
{
    public static GetCoursesWithSkillsQuery MapToQuery(this GetCoursesWithSkillsRequest request)
    {
        return new GetCoursesWithSkillsQuery
        (
            Semester: request.Semester,
            Track: request.Track,
            IsProspectiveStudent: request.IsProspectiveStudent
        );
    }
}