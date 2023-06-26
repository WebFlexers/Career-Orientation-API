using CareerOrientation.Data.Entities.Courses;

namespace CareerOrientation.Data.DTOs.Courses.Mappers;

public static class SkillMapper
{
    public static SkillDTO MapToDTO(this Skill skill)
    {
        return new SkillDTO()
        {
            Name = skill.Name,
            Type = skill.Type.ToString()
        };
    }
}