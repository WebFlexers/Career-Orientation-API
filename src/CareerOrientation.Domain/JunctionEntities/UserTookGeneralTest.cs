using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class UserTookGeneralTest
{
    public int GeneralTestId { get; set; }
    public string UserId { get; set; }

    public GeneralTest GeneralTest { get; set; }
    public User User { get; set; }

    public UserTookGeneralTest(string userId, int generalTestId)
    {
        GeneralTestId = generalTestId;
        UserId = userId;
    }
}
