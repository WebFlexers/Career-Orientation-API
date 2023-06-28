using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

public class UniversityTestConfig : IEntityTypeConfiguration<UniversityTest>
{
    public void Configure(EntityTypeBuilder<UniversityTest> builder)
    {
        builder.HasKey(x => x.UniversityTestId);

        builder.Property(x => x.Semester)
            .IsRequired(false);

        builder.Property(x => x.Year)
            .IsRequired();

        builder.Property(x => x.IsRevision)
            .IsRequired();

        builder.Property(x => x.TrackId)
            .IsRequired(false);

        builder.HasOne(universityTest => universityTest.Track)
            .WithMany(track => track.UniversityTests)
            .HasForeignKey(universityTest => universityTest.TrackId);
    }
}
