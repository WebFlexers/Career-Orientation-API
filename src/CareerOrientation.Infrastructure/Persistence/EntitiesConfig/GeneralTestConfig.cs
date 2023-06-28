using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

public class GeneralTestConfig : IEntityTypeConfiguration<GeneralTest>
{
    public void Configure(EntityTypeBuilder<GeneralTest> builder)
    {
        builder.HasKey(x => x.GeneralTestId);

        builder.Property(x => x.Type)
            .IsRequired();
    }
}
