using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class UserTrueFalseAnswer
{
    public int QuestionId { get; set; }
    public string UserId { get; set; }

    public TrueFalseAnswer TrueFalseAnswer { get; set; }
    public User User { get; set; }
}
