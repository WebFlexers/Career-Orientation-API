using CareerOrientation.Data.Entities.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Tests;

public class LikertScaleAnswersConfig : IEntityTypeConfiguration<LikertScaleAnswers>
{
    public void Configure(EntityTypeBuilder<LikertScaleAnswers> builder)
    {
        builder.HasKey(x => x.LikertScaleAnswerId);
        
        builder.Property(x => x.Option1)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Option2)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Option3)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Option4)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Option5)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(x => x.Questions)
            .WithMany(x => x.LikertScaleAnswers)
            .UsingEntity<QuestionLikertScaleAnswers>();
    }
}