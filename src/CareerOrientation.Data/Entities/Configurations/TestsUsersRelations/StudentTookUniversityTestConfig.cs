using CareerOrientation.Data.Entities.TestsUsersRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsUsersRelations;

public class StudentTookUniversityTestConfig : IEntityTypeConfiguration<StudentTookUniversityTest>
{
    public void Configure(EntityTypeBuilder<StudentTookUniversityTest> builder)
    {
        builder.HasKey(x => new { x.UniversityTestId, x.UserId });
    }
}
