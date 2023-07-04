using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class UserTrueFalseAnswerConfig : IEntityTypeConfiguration<UserTrueFalseAnswer>
{
    public void Configure(EntityTypeBuilder<UserTrueFalseAnswer> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.UserId});

        builder.Property(x => x.Value)
            .IsRequired();

        builder.HasOne(userTrueFalseAnswer => userTrueFalseAnswer.Question)
            .WithMany(question => question.UsersTrueFalseAnswers)
            .HasForeignKey(userTrueFalseAnswer => userTrueFalseAnswer.QuestionId)
            .IsRequired();
        
        builder.HasOne(userTrueFalseAnswer => userTrueFalseAnswer.User)
            .WithMany(user => user.UserTrueFalseAnswers)
            .HasForeignKey(userTrueFalseAnswer => userTrueFalseAnswer.UserId)
            .IsRequired();
    }
}
