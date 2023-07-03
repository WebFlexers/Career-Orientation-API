using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Statistics.Common;
using CareerOrientation.Application.Statistics.Common.Mapping;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.Entities.Enums;

using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class StatisticsRepository : RepositoryBase, IStatisticsRepository
{
    public StatisticsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<TeachingAccessStatResult>> GetUserTeachingAccessStats(string userId,
        CancellationToken cancellationToken)
    {
        var result = await _dbContext.Statistics
            .AsNoTracking()
            .Where(s => s.UserId == userId)
            .Select(s => s.MapToTeachingAccessStatResult())
            .ToListAsync(cancellationToken);

        return result;
    }
    
    public async Task IncrementSemesterTeachingAccessStat(string userId, int semester, 
        CancellationToken cancellationToken)
    {
        var userSemesterAccessCount = _dbContext.Statistics.FirstOrDefault(
            x => x.UserId == userId &&
                         x.Semester == semester);

        if (userSemesterAccessCount is null)
        {
            await _dbContext.Statistics.AddAsync(new Statistics()
            {
                UserId = userId, AccessCount = 1, Semester = semester, Type = StatisticType.TeachingAccessCount
            }, cancellationToken);
        }
        else
        {
            userSemesterAccessCount.AccessCount += 1;
        }

        await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}