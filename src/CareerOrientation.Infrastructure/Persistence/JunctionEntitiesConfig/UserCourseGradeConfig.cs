using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class UserCourseGradeConfig : IEntityTypeConfiguration<UserCourseGrade>
{
    public void Configure(EntityTypeBuilder<UserCourseGrade> builder)
    {
        builder.HasKey(x => new { x.UserId, x.CourseId });

        builder.Property(x => x.Value)
            .IsRequired();
        
        builder.HasOne(scg => scg.User)
            .WithMany(s => s.UserCourseGrades)
            .HasForeignKey(scg => scg.UserId);

        builder.HasOne(scg => scg.Course)
            .WithMany(c => c.UserCourseGrades)
            .HasForeignKey(scg => scg.CourseId);
    }
}