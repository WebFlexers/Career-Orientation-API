using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class QuestionLikertScaleAnswersConfig : IEntityTypeConfiguration<QuestionLikertScaleAnswers>
{
    public void Configure(EntityTypeBuilder<QuestionLikertScaleAnswers> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.LikertScaleAnswersId });
    }
}