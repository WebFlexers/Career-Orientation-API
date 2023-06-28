using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class UserLikertScaleAnswerConfig : IEntityTypeConfiguration<UserLikertScaleAnswer>
{
    public void Configure(EntityTypeBuilder<UserLikertScaleAnswer> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.UserId});

        builder.Property(x => x.Value)
            .IsRequired();
    }
}
