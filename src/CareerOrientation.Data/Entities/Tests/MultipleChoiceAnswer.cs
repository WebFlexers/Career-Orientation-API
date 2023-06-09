using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.Tests;

public class MultipleChoiceAnswer
{
    public int MultipleChoiceAnswerId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public List<User>? UsersAnswered { get; set; }
}
