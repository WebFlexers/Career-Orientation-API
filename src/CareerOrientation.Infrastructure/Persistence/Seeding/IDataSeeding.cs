using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Seeding;

public interface IDataSeeding
{ 
    Task Seed(ModelBuilder builder);
}