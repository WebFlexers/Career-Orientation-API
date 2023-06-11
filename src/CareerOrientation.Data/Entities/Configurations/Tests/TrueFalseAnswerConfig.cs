using CareerOrientation.Data.Entities.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Tests;

public class TrueFalseAnswerConfig : IEntityTypeConfiguration<TrueFalseAnswer>
{
    public void Configure(EntityTypeBuilder<TrueFalseAnswer> builder)
    {
        builder.HasKey(x => x.QuestionId);

        builder.Property(x => x.Value)
            .IsRequired();

        builder.Property(x => x.QuestionId)
            .IsRequired();

        // One to one relationships
        builder.HasOne(trueFalse => trueFalse.Question)
            .WithOne(question => question.TrueFalseAnswer)
            .HasForeignKey<TrueFalseAnswer>(trueFalse => trueFalse.QuestionId);
    }
}
