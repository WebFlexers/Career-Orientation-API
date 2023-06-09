using CareerOrientation.Data.Entities.Specialties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Specialties;

public class ProfessionConfig : IEntityTypeConfiguration<Profession>
{
    public void Configure(EntityTypeBuilder<Profession> builder)
    {
        builder.HasKey(x => x.ProfessionId);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
