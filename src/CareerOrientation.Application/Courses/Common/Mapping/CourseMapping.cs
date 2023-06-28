using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Courses.Common.Mapping;

public static class CourseMapping
{
    public static CoursesWithSkillsResult CreateCourseWithSkills(this Course course, List<Skill> skills)
    {
        List<SkillResult> skillResults = new();
        foreach (var skill in skills)
        {
            skillResults.Add(skill.MapToResult());
        }

        return new CoursesWithSkillsResult(
            Name: course.Name,
            Description: course.Description,
            Track: course?.Track?.Name,
            Skills: skillResults);
    }
}