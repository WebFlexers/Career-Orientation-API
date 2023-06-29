using CareerOrientation.Application.ProspectiveStudentTests.Common;
using CareerOrientation.Application.StudentTests.Common;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface ITestsRepository
{
    Task<StudentTestResult?> GetSemesterTestQuestionsWithAnswers(int? semester, 
        string? track, CancellationToken cancellationToken);

    Task<StudentTestResult?> GetRevisionTestQuestionsWithAnswers(int? year, 
        string? track, CancellationToken cancellationToken);

    Task<ProspectiveStudentTestResult?> GetGeneralTestQuestionsWithAnswers(
        int generalTestId, CancellationToken cancellationToken);
}