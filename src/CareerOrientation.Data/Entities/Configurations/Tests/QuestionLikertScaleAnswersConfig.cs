using CareerOrientation.Data.Entities.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Tests;

public class QuestionLikertScaleAnswersConfig : IEntityTypeConfiguration<QuestionLikertScaleAnswers>
{
    public void Configure(EntityTypeBuilder<QuestionLikertScaleAnswers> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.LikertScaleAnswersId });
    }
}