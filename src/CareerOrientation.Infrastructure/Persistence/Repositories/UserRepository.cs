using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetUserById(string userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FindAsync(new object?[] { userId }, cancellationToken);
    }
    
    public async Task<UniversityStudent?> GetUniversityStudentById(string? userId, bool includeTrack = true)
    {
        if (userId is null) return null;

        if (includeTrack)
        {
            return await _dbContext.UniversityStudents
                .AsNoTracking()
                .Include(us => us.Track)
                .FirstOrDefaultAsync(us => us.UserId == userId);
        }
        else
        {
            return await _dbContext.UniversityStudents
                .AsNoTracking()
                .FirstOrDefaultAsync(us => us.UserId == userId);
        }
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