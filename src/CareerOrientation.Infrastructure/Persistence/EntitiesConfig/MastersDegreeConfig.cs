using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

public class MastersDegreeConfig : IEntityTypeConfiguration<MastersDegree>
{
    public void Configure(EntityTypeBuilder<MastersDegree> builder)
    {
        builder.HasKey(x => x.MastersDegreeId);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
