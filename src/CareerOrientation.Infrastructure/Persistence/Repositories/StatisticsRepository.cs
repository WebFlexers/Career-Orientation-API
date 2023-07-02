namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class StatisticsRepository : RepositoryBase
{
    public StatisticsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task IncrementSemesterTeachingAccessStat(string userId, int? semester)
    {
        throw new NotImplementedException();
    }
}