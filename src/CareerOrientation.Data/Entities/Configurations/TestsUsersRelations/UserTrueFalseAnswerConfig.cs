using CareerOrientation.Data.Entities.TestsUsersRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsUsersRelations;

public class UserTrueFalseAnswerConfig : IEntityTypeConfiguration<UserTrueFalseAnswer>
{
    public void Configure(EntityTypeBuilder<UserTrueFalseAnswer> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.UserId});

        builder.HasOne(userMultipleChoice => userMultipleChoice.TrueFalseAnswer)
            .WithMany()
            .HasForeignKey(userMultipleChoice => userMultipleChoice.QuestionId);
    }
}
