using CareerOrientation.Data.Entities.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Tests;

public class QuestionConfig : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.QuestionId);

        builder.Property(x => x.Text)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.GeneralTestId)
            .IsRequired(false);

        builder.Property(x => x.UniversityTestId)
            .IsRequired(false);

        builder.HasOne(question => question.GeneralTest)
            .WithMany(generalTest => generalTest.Questions)
            .HasForeignKey(question => question.GeneralTestId);

        builder.HasOne(question => question.UniversityTest)
            .WithMany(universityTest => universityTest.Questions)
            .HasForeignKey(question => question.UniversityTestId);
    }
}
