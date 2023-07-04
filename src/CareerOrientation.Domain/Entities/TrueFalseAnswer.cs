using CareerOrientation.Domain.JunctionEntities;

namespace CareerOrientation.Domain.Entities;

public class TrueFalseAnswer
{
    public int TrueFalseAnswerId { get; set; }
    public bool Value { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
