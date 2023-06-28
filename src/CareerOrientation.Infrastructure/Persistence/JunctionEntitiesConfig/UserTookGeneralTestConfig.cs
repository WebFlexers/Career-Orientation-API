using CareerOrientation.Domain.JunctionEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.JunctionEntitiesConfig;

public class UserTookGeneralTestConfig : IEntityTypeConfiguration<UserTookGeneralTest>
{
    public void Configure(EntityTypeBuilder<UserTookGeneralTest> builder)
    {
        builder.HasKey(x => new { x.GeneralTestId, x.UserId });
    }
}
