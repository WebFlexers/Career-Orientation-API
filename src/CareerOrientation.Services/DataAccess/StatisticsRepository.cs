using CareerOrientation.Data;
using Microsoft.Extensions.Logging;
using CareerOrientation.Data.Entities.Users;

namespace CareerOrientation.Services.DataAccess;

public class StatisticsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StatisticsRepository(ILogger<StatisticsRepository> logger, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User GetResult()
    {
        return new User();
    }
}
