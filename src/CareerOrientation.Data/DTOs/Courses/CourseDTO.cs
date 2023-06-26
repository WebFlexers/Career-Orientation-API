namespace CareerOrientation.Data.DTOs.Courses;

public class CourseDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<SkillDTO> Skills { get; set; }
}