using CareerOrientation.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Users;

public class UniversityStudentConfig : IEntityTypeConfiguration<UniversityStudent>
{
    public void Configure(EntityTypeBuilder<UniversityStudent> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.Semester)
            .IsRequired(false); 

        builder.Property(x => x.IsGraduate)
            .IsRequired();

        builder.Property(x => x.TrackId)
            .IsRequired(false);

        builder.HasOne(student => student.User)
            .WithOne(user => user.UniversityStudent)
            .HasForeignKey<UniversityStudent>(student => student.UserId);

        builder.HasOne(student => student.Track)
            .WithMany(track => track.UniversityStudents)
            .HasForeignKey(student => student.TrackId);
    }
}
