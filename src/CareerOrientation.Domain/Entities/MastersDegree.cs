namespace CareerOrientation.Domain.Entities;

public class MastersDegree
{
    public int MastersDegreeId { get; init; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }

    public List<Track> Tracks { get; set; }
    
    public override bool Equals(object obj)
    {
        if (obj is not MastersDegree otherDegree)
            return false;

        return MastersDegreeId == otherDegree.MastersDegreeId;
    }

    public override int GetHashCode()
    {
        return MastersDegreeId.GetHashCode();
    }
}
