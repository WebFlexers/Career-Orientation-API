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

        builder.HasOne(userMultipleChoice => userMultipleChoice.TrueFalseAnswer)
            .WithMany()
            .HasForeignKey(userMultipleChoice => userMultipleChoice.QuestionId);
        
        builder.HasOne(userMultipleChoice => userMultipleChoice.User)
            .WithMany()
            .HasForeignKey(userMultipleChoice => userMultipleChoice.UserId);
    }
}
