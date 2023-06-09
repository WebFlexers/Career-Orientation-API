using CareerOrientation.Data.Entities.TestsUsersRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsUsersRelations;

public class UserTookGeneralTestConfig : IEntityTypeConfiguration<UserTookGeneralTest>
{
    public void Configure(EntityTypeBuilder<UserTookGeneralTest> builder)
    {
        builder.HasKey(x => new { x.GeneralTestId, x.UserId });
    }
}
