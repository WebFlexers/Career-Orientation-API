using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Domain.Entities;

public class Skill
{
    public int SkillId { get; set; }
    public string Name { get; set; }
    public SkillType Type { get; set; }

    public List<Course>? Courses { get; set; }
}
