using CareerOrientation.Data.Entities.Courses.Enums;

namespace CareerOrientation.Data.Entities.Courses;

public class Skill
{
    public int SkillId { get; set; }
    public string Name { get; set; }
    public SkillType Type { get; set; }

    public List<Course>? Courses { get; set; }
}
