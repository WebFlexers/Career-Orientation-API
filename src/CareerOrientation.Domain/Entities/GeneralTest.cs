using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Domain.Entities;

public class GeneralTest
{
    public int GeneralTestId { get; set; }
    public GeneralTestType Type { get; set; }

    public List<Question> Questions { get; set; }
    public List<User> UsersTookTest { get; set; }
}
