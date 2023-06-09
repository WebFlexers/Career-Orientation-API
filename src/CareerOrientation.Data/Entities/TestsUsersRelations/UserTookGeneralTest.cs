using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Data.Entities.TestsUsersRelations;

public class UserTookGeneralTest
{
    public int GeneralTestId { get; set; }
    public string UserId { get; set; }

    public GeneralTest GeneralTest { get; set; }
    public User User { get; set; }
}
