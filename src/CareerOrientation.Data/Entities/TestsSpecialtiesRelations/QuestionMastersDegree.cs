using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;

namespace CareerOrientation.Data.Entities.TestsSpecialtiesRelations;

public class QuestionMastersDegree
{
    public int QuestionId { get; set; }
    public int MastersDegreeId { get; set; }

    public Question Question { get; set; }
    public MastersDegree MastersDegree { get; set; }
}
