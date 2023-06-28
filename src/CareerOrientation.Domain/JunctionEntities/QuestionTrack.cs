using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Domain.JunctionEntities;

public class QuestionTrack
{
    public int QuestionId { get; set; }
    public int TrackId { get; set; }

    public Question Question { get; set; }
    public Track Track { get; set; }
}
