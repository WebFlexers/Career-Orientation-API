namespace CareerOrientation.Domain.Entities;

public class Profession
{
    public int ProfessionId { get; set; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }

    public List<Track> Tracks { get; set; }
}
