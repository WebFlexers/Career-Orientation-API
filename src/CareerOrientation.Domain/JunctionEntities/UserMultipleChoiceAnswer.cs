using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class UserMultipleChoiceAnswer
{
    public int QuestionId { get; set; }
    public string UserId { get; set; }

    public MultipleChoiceAnswer MultipleChoiceAnswer { get; set; }
    public User User { get; set; }
}
