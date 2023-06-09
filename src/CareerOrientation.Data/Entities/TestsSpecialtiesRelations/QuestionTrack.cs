using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;

namespace CareerOrientation.Data.Entities.TestsSpecialtiesRelations;

public class QuestionTrack
{
    public int QuestionId { get; set; }
    public int TrackId { get; set; }

    public Question Question { get; set; }
    public Track Track { get; set; }
}
