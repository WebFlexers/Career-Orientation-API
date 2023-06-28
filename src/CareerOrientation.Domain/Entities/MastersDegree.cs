namespace CareerOrientation.Domain.Entities;

public class MastersDegree
{
    public int MastersDegreeId { get; set; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }

    public List<Track> Tracks { get; set; }
}
