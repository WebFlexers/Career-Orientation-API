using CareerOrientation.Data.Entities.Specialties;

namespace CareerOrientation.Data.Entities.SpecialtiesRelations;

public class TrackMastersDegree
{
    public int TrackId { get; set; }
    public int MastersDegreeId { get; set; }

    public Track Track { get; set; }
    public MastersDegree MastersDegree { get; set; }
}
