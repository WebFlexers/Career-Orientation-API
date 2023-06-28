using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class StudentTookUniversityTestConfig : IEntityTypeConfiguration<StudentTookUniversityTest>
{
    public void Configure(EntityTypeBuilder<StudentTookUniversityTest> builder)
    {
        builder.HasKey(x => new { x.UniversityTestId, x.UserId });
    }
}
