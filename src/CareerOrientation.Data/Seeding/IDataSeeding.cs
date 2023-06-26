using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Data.Seeding;

public interface IDataSeeding
{ 
    Task Seed(ModelBuilder builder);
}