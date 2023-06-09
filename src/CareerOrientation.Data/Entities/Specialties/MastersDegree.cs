using CareerOrientation.Data.Entities.Tests;

namespace CareerOrientation.Data.Entities.Specialties;

public class MastersDegree
{
    public int MastersDegreeId { get; set; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }
}
