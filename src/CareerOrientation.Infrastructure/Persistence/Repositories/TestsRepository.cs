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

    public async Task<List<StudentTestResult>> GetSemesterTestQuestionsWithAnswers(int? semester, 
        string? track, CancellationToken cancellationToken)
    {
        List<StudentTestResult> studentTestResults;
        
        if (track is null)
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Semester == semester)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .ToListAsync(cancellationToken);
        }
        else
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Semester == semester && t.Track!.Name == track)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .ToListAsync(cancellationToken);
        }
        
        return studentTestResults;
    }

    public async Task<List<StudentTestResult>> GetRevisionTestQuestionsWithAnswers(int? year, 
        string? track, CancellationToken cancellationToken)
    {
        List<StudentTestResult> studentTestResults;

        if (string.IsNullOrWhiteSpace(track))
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Year == year && t.IsRevision)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .ToListAsync(cancellationToken);
        }
        else
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Year == year && t.IsRevision && t.Track!.Name == track)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .ToListAsync(cancellationToken);
        }
   

        return studentTestResults;
    }
}