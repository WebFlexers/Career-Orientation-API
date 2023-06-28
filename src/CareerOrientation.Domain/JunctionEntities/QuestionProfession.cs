using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class QuestionProfession
{
    public int QuestionId { get; set; }
    public int ProfessionId { get; set; }

    public Question Question { get; set; }
    public Profession Profession { get; set; }
}
