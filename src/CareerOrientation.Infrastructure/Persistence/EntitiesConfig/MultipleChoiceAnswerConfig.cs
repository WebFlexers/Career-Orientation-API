using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

public class MultipleChoiceAnswerConfig : IEntityTypeConfiguration<MultipleChoiceAnswer>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceAnswer> builder)
    {
        builder.HasKey(x => x.MultipleChoiceAnswerId);

        builder.Property(x => x.Text)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.IsCorrect)
            .IsRequired();

        builder.Property(x => x.QuestionId)
            .IsRequired();

        // One to many relationships
        builder.HasOne(multipleChoice => multipleChoice.Question)
            .WithMany(question => question.MultipleChoiceAnswers)
            .HasForeignKey(multipleChoice => multipleChoice.QuestionId);
    }
}
