using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.IsProspectiveStudent)
            .IsRequired();

        // Many to many relations
        // Answers
        builder.HasMany(user => user.MultipleChoiceAnswers)
            .WithMany(multipleChoice => multipleChoice.UsersAnswered)
            .UsingEntity<UserMultipleChoiceAnswer>();

        builder.HasMany(user => user.TrueFalseAnswers)
            .WithMany(trueFalse => trueFalse.UsersAnswered)
            .UsingEntity<UserTrueFalseAnswer>();

        // Tests
        builder.HasMany(user => user.CompletedGeneralTests)
            .WithMany(generalTest => generalTest.UsersTookTest)
            .UsingEntity<UserTookGeneralTest>();

        builder.HasMany(user => user.CompletedUniversityTests)
            .WithMany(uniTest => uniTest.UsersTookTest)
            .UsingEntity<StudentTookUniversityTest>();
        
        // Statistics

    }
}
