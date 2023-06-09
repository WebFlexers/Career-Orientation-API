using CareerOrientation.Data.Entities.TestsSpecialtiesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsSpecialtiesRelations;

public class QuestionProfessionConfig : IEntityTypeConfiguration<QuestionProfession>
{
    public void Configure(EntityTypeBuilder<QuestionProfession> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.ProfessionId });
    }
}
