using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Courses.Common.Mapping;

public static class SkillMapping
{
    public static SkillResult MapToResult(this Skill skill)
    {
        return new SkillResult(
            Name: skill.Name,
            Type: skill.Type.ToString());
    }
}