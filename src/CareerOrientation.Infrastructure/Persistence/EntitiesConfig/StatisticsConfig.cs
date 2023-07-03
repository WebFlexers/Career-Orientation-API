using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Infrastructure.Persistence.EntitiesConfig;

public class StatisticsConfig : IEntityTypeConfiguration<Statistics>
{
    public void Configure(EntityTypeBuilder<Statistics> builder)
    {
        builder.HasKey(x => x.StatisticsId);

        builder.Property(x => x.Semester)
            .IsRequired();

        builder.Property(x => x.AccessCount)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasOne(stats => stats.User)
            .WithMany(user => user.Statistics)
            .HasForeignKey(stats => stats.UserId);
    }
}