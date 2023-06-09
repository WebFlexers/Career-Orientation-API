using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.TestsUsersRelations;

public class UserTrueFalseAnswer
{
    public int TrueFalseAnswerId { get; set; }
    public string UserId { get; set; }

    public TrueFalseAnswer TrueFalseAnswer { get; set; }
    public User User { get; set; }
}
