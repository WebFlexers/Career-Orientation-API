using CareerOrientation.Data.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Courses;

public class CourseSkillConfig : IEntityTypeConfiguration<CourseSkill>
{
    public void Configure(EntityTypeBuilder<CourseSkill> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.SkillId });
    }
}
