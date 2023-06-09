using CareerOrientation.Data.Entities.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Tests;

public class GeneralTestConfig : IEntityTypeConfiguration<GeneralTest>
{
    public void Configure(EntityTypeBuilder<GeneralTest> builder)
    {
        builder.HasKey(x => x.GeneralTestId);

        builder.Property(x => x.Type)
            .IsRequired();
    }
}
