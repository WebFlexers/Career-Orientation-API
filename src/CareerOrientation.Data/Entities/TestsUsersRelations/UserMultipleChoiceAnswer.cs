using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.TestsUsersRelations;

public class UserMultipleChoiceAnswer
{
    public int MultipleChoiceAnswerId { get; set; }
    public string UserId { get; set; }

    public MultipleChoiceAnswer MultipleChoiceAnswer { get; set; }
    public User User { get; set; }
}
