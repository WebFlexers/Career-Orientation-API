using CareerOrientation.Data.Entities.Tests;

namespace CareerOrientation.Data.Entities.Specialties;

public class Profession
{
    public int ProfessionId { get; set; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }

    public List<Track> Tracks { get; set; }
}
