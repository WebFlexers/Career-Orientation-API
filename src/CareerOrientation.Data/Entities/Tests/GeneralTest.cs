using CareerOrientation.Data.Entities.Tests.Enums;

namespace CareerOrientation.Data.Entities.Tests;

public class GeneralTest
{
    public int GeneralTestId { get; set; }
    public GeneralTestType Type { get; set; }

    public List<Question> Questions { get; set; }
}
