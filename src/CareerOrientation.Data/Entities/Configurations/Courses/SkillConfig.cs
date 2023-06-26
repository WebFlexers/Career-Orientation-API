using CareerOrientation.Data.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Courses;

public class SkillConfig : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(x => x.SkillId);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.Type)
            .IsRequired();
    }
}
