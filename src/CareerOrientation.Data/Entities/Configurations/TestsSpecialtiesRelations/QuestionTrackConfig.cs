using CareerOrientation.Data.Entities.TestsSpecialtiesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsSpecialtiesRelations;

public class QuestionTrackConfig : IEntityTypeConfiguration<QuestionTrack>
{
    public void Configure(EntityTypeBuilder<QuestionTrack> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.TrackId });
    }
}
