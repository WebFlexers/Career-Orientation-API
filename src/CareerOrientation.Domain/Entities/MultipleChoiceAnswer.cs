using CareerOrientation.Domain.JunctionEntities;

namespace CareerOrientation.Domain.Entities;

public class MultipleChoiceAnswer
{
    public int MultipleChoiceAnswerId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public List<UserMultipleChoiceAnswer>? UserMultipleChoiceAnswers { get; set; }
}
