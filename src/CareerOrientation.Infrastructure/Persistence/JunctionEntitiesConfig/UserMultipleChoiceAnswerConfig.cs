using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class UserMultipleChoiceAnswerConfig : IEntityTypeConfiguration<UserMultipleChoiceAnswer>
{
    public void Configure(EntityTypeBuilder<UserMultipleChoiceAnswer> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.UserId});

        builder.HasOne(userMultipleChoice => userMultipleChoice.MultipleChoiceAnswer)
            .WithMany()
            .HasForeignKey(userMultipleChoice => userMultipleChoice.QuestionId);
    }
}
