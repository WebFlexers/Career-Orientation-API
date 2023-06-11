using CareerOrientation.Data.Entities.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Tests;

public class MultipleChoiceAnswerConfig : IEntityTypeConfiguration<MultipleChoiceAnswer>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceAnswer> builder)
    {
        builder.HasKey(x => x.QuestionId);

        builder.Property(x => x.Text)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.IsCorrect)
            .IsRequired();

        // One to many relationships
        builder.HasOne(multipleChoice => multipleChoice.Question)
            .WithMany(question => question.MultipleChoiceAnswers)
            .HasForeignKey(multipleChoice => multipleChoice.QuestionId);
    }
}
