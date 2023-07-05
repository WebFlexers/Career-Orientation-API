namespace CareerOrientation.Domain.Entities;

public class Profession
{
    public int ProfessionId { get; init; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }

    public List<Track> Tracks { get; set; }
    
    public override bool Equals(object obj)
    {
        if (obj is not Profession otherProfession)
            return false;

        return ProfessionId == otherProfession.ProfessionId;
    }

    public override int GetHashCode()
    {
        return ProfessionId.GetHashCode();
    }
}
