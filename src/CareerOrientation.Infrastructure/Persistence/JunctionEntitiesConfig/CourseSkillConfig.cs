using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class CourseSkillConfig : IEntityTypeConfiguration<CourseSkill>
{
    public void Configure(EntityTypeBuilder<CourseSkill> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.SkillId });
    }
}
