using CareerOrientation.Data.Entities.UsersCoursesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.UsersCoursesRelations;

public class UserCourseStatisticsConfig : IEntityTypeConfiguration<UserCourseStatistics>
{
    public void Configure(EntityTypeBuilder<UserCourseStatistics> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.UserId });

        builder.Property(x => x.AccessCount)
            .IsRequired();
    }
}
