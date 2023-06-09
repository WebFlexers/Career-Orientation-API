using CareerOrientation.Data.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Courses;

public class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.CourseId);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(x => x.Semester)
            .IsRequired();

        builder.Property(x => x.TrackId)
            .IsRequired(false);

        // One to mane relations
        builder.HasOne(course => course.Track)
            .WithMany(track => track.Courses)
            .HasForeignKey(course => course.TrackId);

        // Many to many relations
        builder.HasMany(course => course.Skills)
            .WithMany(skills => skills.Courses)
            .UsingEntity<CourseSkill>();
    }
}
