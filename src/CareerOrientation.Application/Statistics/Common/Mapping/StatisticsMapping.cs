
namespace CareerOrientation.Application.Statistics.Common.Mapping;

public static class StatisticsMapping
{
    public static TeachingAccessStatResult MapToTeachingAccessStatResult(this Domain.Entities.Statistics statistics)
    {
        return new TeachingAccessStatResult(
            Semester: statistics.Semester,
            AccessCount: statistics.AccessCount);
    }
}