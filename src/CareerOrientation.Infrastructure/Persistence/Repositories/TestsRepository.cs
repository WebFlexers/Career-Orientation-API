using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.StudentTests.Common;
using CareerOrientation.Application.StudentTests.Common.Mapping;

using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class TestsRepository : RepositoryBase, ITestsRepository
{
    public TestsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<StudentTestResult>> GetSemesterTestQuestions(int? semester, 
        CancellationToken cancellationToken)
    {
        var questions = await _dbContext.UniversityTests
            .AsNoTracking()
            .Where(t => t.Semester == semester)
            .Include(t => t.Questions)
            .Select(t => t.MapToStudentTestResult())
            .ToListAsync(cancellationToken);

        return questions;
    }

    public async Task<List<StudentTestResult>> GetRevisionTestQuestions(int? year, CancellationToken cancellationToken)
    {
        var questions = await _dbContext.UniversityTests
            .AsNoTracking()
            .Where(t => t.Year == year && t.IsRevision)
            .Include(t => t.Questions)
            .Select(t => t.MapToStudentTestResult())
            .ToListAsync(cancellationToken);

        return questions;
    }
}