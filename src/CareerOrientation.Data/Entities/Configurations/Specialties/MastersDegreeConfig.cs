using CareerOrientation.Data.Entities.Specialties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.Specialties;

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
