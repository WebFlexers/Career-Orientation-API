using CareerOrientation.Data.Entities.UsersCoursesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.UsersCoursesRelations;

public class GradeConfig : IEntityTypeConfiguration<UserCourseGrade>
{
    public void Configure(EntityTypeBuilder<UserCourseGrade> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.UserId });

        builder.Property(x => x.Value)
            .IsRequired();
    }
}
