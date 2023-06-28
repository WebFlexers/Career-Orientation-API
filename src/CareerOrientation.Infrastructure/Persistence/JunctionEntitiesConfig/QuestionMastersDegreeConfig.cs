using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class QuestionMastersDegreeConfig : IEntityTypeConfiguration<QuestionMastersDegree>
{
    public void Configure(EntityTypeBuilder<QuestionMastersDegree> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.MastersDegreeId });
    }
}
