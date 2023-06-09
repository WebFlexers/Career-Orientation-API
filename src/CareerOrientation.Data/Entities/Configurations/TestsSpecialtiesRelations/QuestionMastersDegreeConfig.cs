using CareerOrientation.Data.Entities.TestsSpecialtiesRelations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerOrientation.Data.Entities.Configurations.TestsSpecialtiesRelations;

public class QuestionMastersDegreeConfig : IEntityTypeConfiguration<QuestionMastersDegree>
{
    public void Configure(EntityTypeBuilder<QuestionMastersDegree> builder)
    {
        builder.HasKey(x => new { x.QuestionId, x.MastersDegreeId });
    }
}
