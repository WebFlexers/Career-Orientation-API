using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class QuestionTrackConfig : IEntityTypeConfiguration<QuestionTrack>
{
    public void Configure(EntityTypeBuilder<QuestionTrack> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.TrackId });
    }
}
