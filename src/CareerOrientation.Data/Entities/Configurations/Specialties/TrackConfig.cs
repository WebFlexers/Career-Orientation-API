using CareerOrientation.Data.Entities.Specialties;
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
    }
}
