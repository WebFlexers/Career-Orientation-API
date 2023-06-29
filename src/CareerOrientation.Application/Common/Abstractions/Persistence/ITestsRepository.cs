using CareerOrientation.Application.StudentTests.Common;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface ITestsRepository : IRepositoryBase
{
    Task<List<StudentTestResult>> GetSemesterTestQuestionsWithAnswers(int? semester, string? track, 
        CancellationToken cancellationToken);
    Task<List<StudentTestResult>> GetRevisionTestQuestionsWithAnswers(int? year, string? track, 
        CancellationToken cancellationToken);
}