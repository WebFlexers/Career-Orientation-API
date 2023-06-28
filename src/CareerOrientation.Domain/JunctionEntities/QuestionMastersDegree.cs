using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class QuestionMastersDegree
{
    public int QuestionId { get; set; }
    public int MastersDegreeId { get; set; }

    public Question Question { get; set; }
    public MastersDegree MastersDegree { get; set; }
}
