using CareerOrientation.Data.Entities.SpecialtiesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.SpecialtiesRelations;

public class TrackProfessionConfig : IEntityTypeConfiguration<TrackProfession>
{
    public void Configure(EntityTypeBuilder<TrackProfession> builder)
    {
        builder.HasKey(x => new { x.TrackId, x.ProfessionId });
    }
}
