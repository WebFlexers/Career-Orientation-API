using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;

namespace CareerOrientation.Data.Entities.TestsSpecialtiesRelations;

public class QuestionProfession
{
    public int QuestionId { get; set; }
    public int ProfessionId { get; set; }

    public Question Question { get; set; }
    public Profession Profession { get; set; }
}
