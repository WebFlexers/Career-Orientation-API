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
        // Tests
        builder.HasMany(user => user.CompletedGeneralTests)
            .WithMany(generalTest => generalTest.UsersTookTest)
            .UsingEntity<UserTookGeneralTest>();

        builder.HasMany(user => user.CompletedUniversityTests)
            .WithMany(uniTest => uniTest.UsersTookTest)
            .UsingEntity<StudentTookUniversityTest>();
    }
}
