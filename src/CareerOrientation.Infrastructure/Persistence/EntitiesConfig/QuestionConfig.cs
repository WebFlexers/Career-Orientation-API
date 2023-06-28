using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

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

        // One to many relationships
        builder.HasOne(question => question.GeneralTest)
            .WithMany(generalTest => generalTest.Questions)
            .HasForeignKey(question => question.GeneralTestId);

        builder.HasOne(question => question.UniversityTest)
            .WithMany(universityTest => universityTest.Questions)
            .HasForeignKey(question => question.UniversityTestId);

        // Many to many relationships
        builder.HasMany(question => question.MastersDegrees)
            .WithMany(mastersDegree => mastersDegree.Questions)
            .UsingEntity<QuestionMastersDegree>();

        builder.HasMany(question => question.Professions)
            .WithMany(mastersDegree => mastersDegree.Questions)
            .UsingEntity<QuestionProfession>();

        builder.HasMany(question => question.Tracks)
            .WithMany(mastersDegree => mastersDegree.Questions)
            .UsingEntity<QuestionTrack>();
    }
}
