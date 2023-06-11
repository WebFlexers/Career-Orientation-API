using CareerOrientation.Data.Entities.SpecialtiesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.SpecialtiesRelations;

public class TrackMastersDegreeConfig : IEntityTypeConfiguration<TrackMastersDegree>
{
    public void Configure(EntityTypeBuilder<TrackMastersDegree> builder)
    {
        builder.HasKey(x => new { x.TrackId, x.MastersDegreeId });
    }
}
