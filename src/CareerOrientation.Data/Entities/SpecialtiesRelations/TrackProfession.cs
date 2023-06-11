using CareerOrientation.Data.Entities.Specialties;

namespace CareerOrientation.Data.Entities.SpecialtiesRelations;

public class TrackProfession
{
    public int TrackId { get; set; }
    public int ProfessionId { get; set; }

    public Track Track { get; set; }
    public Profession Profession { get; set; }
}
