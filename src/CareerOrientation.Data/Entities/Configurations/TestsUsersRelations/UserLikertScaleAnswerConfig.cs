using CareerOrientation.Data.Entities.TestsUsersRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsUsersRelations;

public class UserLikertScaleAnswerConfig : IEntityTypeConfiguration<UserLikertScaleAnswer>
{
    public void Configure(EntityTypeBuilder<UserLikertScaleAnswer> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.UserId});

        builder.Property(x => x.Value)
            .IsRequired();
    }
}
