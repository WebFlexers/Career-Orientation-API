using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class TrackMastersDegreeConfig : IEntityTypeConfiguration<TrackMastersDegree>
{
    public void Configure(EntityTypeBuilder<TrackMastersDegree> builder)
    {
        builder.HasKey(x => new { x.TrackId, x.MastersDegreeId });
    }
}
