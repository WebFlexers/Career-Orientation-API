using CareerOrientation.Application.StudentTests.Common;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface ITestsRepository : IRepositoryBase
{
    Task<List<StudentTestResult>> GetSemesterTestQuestions(int? semester, CancellationToken cancellationToken);
    Task<List<StudentTestResult>> GetRevisionTestQuestions(int? year, CancellationToken cancellationToken);
}