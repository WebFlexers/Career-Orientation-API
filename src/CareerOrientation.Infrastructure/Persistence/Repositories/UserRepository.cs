using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddUniversityStudent(UniversityStudent student)
    {
        if (student.IsGraduate)
        {
            student.Semester = null;
        }
        
        await _dbContext.AddAsync(student);
        if (IsTransactionRunning == false)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}