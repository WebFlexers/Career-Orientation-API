using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class UserLikertScaleAnswer
{
    public int QuestionId { get; set; }
    public string UserId { get; set; }
    public int Value { get; set; }

    public Question Question { get; set; }
    public User User { get; set; }
}
