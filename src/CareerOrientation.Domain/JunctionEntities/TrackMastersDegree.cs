using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class TrackMastersDegree
{
    public int TrackId { get; set; }
    public int MastersDegreeId { get; set; }

    public Track Track { get; set; }
    public MastersDegree MastersDegree { get; set; }
}
