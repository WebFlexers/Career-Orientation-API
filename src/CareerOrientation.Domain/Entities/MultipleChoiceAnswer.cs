namespace CareerOrientation.Domain.Entities;

public class MultipleChoiceAnswer
{
    public int MultipleChoiceAnswerId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public List<User>? UsersAnswered { get; set; }
}
