using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

public class TrueFalseAnswerConfig : IEntityTypeConfiguration<TrueFalseAnswer>
{
    public void Configure(EntityTypeBuilder<TrueFalseAnswer> builder)
    {
        builder.HasKey(x => x.TrueFalseAnswerId);

        builder.Property(x => x.Value)
            .IsRequired();

        // One to one relationships
        builder.HasOne(trueFalse => trueFalse.Question)
            .WithOne(question => question.TrueFalseAnswer)
            .HasForeignKey<TrueFalseAnswer>(trueFalse => trueFalse.QuestionId)
            .IsRequired();
    }
}
