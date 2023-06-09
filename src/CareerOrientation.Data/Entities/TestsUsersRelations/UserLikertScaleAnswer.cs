using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.TestsUsersRelations;

public class UserLikertScaleAnswer
{
    public int QuestionId { get; set; }
    public string UserId { get; set; }
    public int Value { get; set; }

    public Question Question { get; set; }
    public User User { get; set; }
}
