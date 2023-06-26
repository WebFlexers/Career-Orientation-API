using CareerOrientation.Data.Entities.Courses;

namespace CareerOrientation.Data.DTOs.Courses.Mappers;

public static class CourseMapper
{
    public static CourseDTO MapToCourseWithSkills(this Course course, List<Skill> skills)
    {
        List<SkillDTO> skillDTOs = new();
        foreach (var skill in skills)
        {
            skillDTOs.Add(skill.MapToDTO());
        }
        
        return new CourseDTO
        {
            Name = course.Name,
            Description = course.Description,
            Skills = skillDTOs
        };
    }
}