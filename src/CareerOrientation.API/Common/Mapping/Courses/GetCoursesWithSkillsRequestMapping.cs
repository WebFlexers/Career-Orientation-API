using CareerOrientation.API.Common.Contracts.Courses;
using CareerOrientation.Application.Courses.Queries.CoursesWithSkillsQuery;

namespace CareerOrientation.API.Common.Mapping.Courses;

public static class GetCoursesWithSkillsRequestMapping
{
    public static CoursesWithSkillsQuery MapToQuery(this GetCoursesWithSkillsRequest request)
    {
        return new CoursesWithSkillsQuery
        (
            Semester: request.Semester,
            Track: request.Track,
            IsProspectiveStudent: request.IsProspectiveStudent
        );
    }
}