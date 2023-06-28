using CareerOrientation.API.Common.Contracts.Courses;
using CareerOrientation.Application.Courses.Common;

namespace CareerOrientation.API.Common.Mapping.Courses;

public static class GetCoursesWithSkillsResultMapping
{
    public static GetCoursesWithSkillsResponse MapToResponse(this CoursesWithSkillsResult result)
    {
        return new GetCoursesWithSkillsResponse(
            Name: result.Name,
            Description: result.Description,
            Track: result.Track,
            Skills: result.Skills);
    }
}