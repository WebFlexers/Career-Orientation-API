using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.SpecialtiesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Specialties;

public class TrackConfig : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.HasKey(x => x.TrackId);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Many to many relations
        builder.HasMany(track => track.MastersDegrees)
            .WithMany(masterDegree => masterDegree.Tracks)
            .UsingEntity<TrackMastersDegree>();

        builder.HasMany(track => track.Professions)
            .WithMany(profession => profession.Tracks)
            .UsingEntity<TrackProfession>();
    }
}
