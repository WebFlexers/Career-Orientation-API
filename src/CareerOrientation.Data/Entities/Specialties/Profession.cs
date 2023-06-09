using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.TestsSpecialtiesRelations;

namespace CareerOrientation.Data.Entities.Specialties;

public class Profession
{
    public int ProfessionId { get; set; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }
}
