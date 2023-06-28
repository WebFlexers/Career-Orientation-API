using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<UniversityStudent?> GetUniversityStudentById(string? userId)
    {
        if (userId is null) return null;
        return await _dbContext.UniversityStudents
            .AsNoTracking()
            .Include(us => us.Track)
            .FirstOrDefaultAsync(us => us.UserId == userId);
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