using CareerOrientation.Application.Statistics.Common;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface IStatisticsRepository : IRepositoryBase
{
    Task IncrementSemesterTeachingAccessStat(string userId, int semester, CancellationToken cancellationToken);
    Task<List<TeachingAccessStatResult>> GetUserTeachingAccessStats(string userId, 
        CancellationToken cancellationToken);
}