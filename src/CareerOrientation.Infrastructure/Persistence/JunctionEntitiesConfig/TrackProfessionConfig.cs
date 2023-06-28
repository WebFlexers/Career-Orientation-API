using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class TrackProfessionConfig : IEntityTypeConfiguration<TrackProfession>
{
    public void Configure(EntityTypeBuilder<TrackProfession> builder)
    {
        builder.HasKey(x => new { x.TrackId, x.ProfessionId });
    }
}
