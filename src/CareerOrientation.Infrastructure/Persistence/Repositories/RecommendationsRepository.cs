namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class RecommendationsRepository : RepositoryBase
{
    public RecommendationsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}