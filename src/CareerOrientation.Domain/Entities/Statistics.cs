using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Domain.Entities;

public class Statistics
{
    public int StatisticsId { get; set; }
    public int Semester { get; set; }
    public int AccessCount { get; set; }
    public StatisticType Type { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
}