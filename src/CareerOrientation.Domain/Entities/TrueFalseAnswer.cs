namespace CareerOrientation.Domain.Entities;

public class TrueFalseAnswer
{
    public bool Value { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public List<User>? UsersAnswered { get; set; }
}
