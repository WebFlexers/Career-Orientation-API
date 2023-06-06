using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.IsUniStudent)
            .IsRequired();
        builder.Property(x => x.Semester)
            .IsRequired(false);
        builder.Property(x => x.Track)
            .IsRequired(false);
    }
}
