using CareerOrientation.Data.Entities.TestsUsersRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsUsersRelations;

public class UserMultipleChoiceAnswerConfig : IEntityTypeConfiguration<UserMultipleChoiceAnswer>
{
    public void Configure(EntityTypeBuilder<UserMultipleChoiceAnswer> builder)
    {
        builder.HasKey(x => new { x.MultipleChoiceAnswerId, x.UserId});
    }
}
