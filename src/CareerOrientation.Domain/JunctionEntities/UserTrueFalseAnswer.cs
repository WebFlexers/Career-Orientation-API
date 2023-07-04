using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class UserTrueFalseAnswer
{
    public int QuestionId { get; set; }
    public string UserId { get; set; }
    public bool Value { get; set; }

    public Question Question { get; set; }
    public User User { get; set; }
}
