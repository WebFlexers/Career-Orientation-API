using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class QuestionProfessionConfig : IEntityTypeConfiguration<QuestionProfession>
{
    public void Configure(EntityTypeBuilder<QuestionProfession> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.ProfessionId });
    }
}
