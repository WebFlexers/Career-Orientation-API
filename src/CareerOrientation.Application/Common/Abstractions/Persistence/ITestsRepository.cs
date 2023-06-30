using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;
using CareerOrientation.Application.Tests.StudentTests.Common;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface ITestsRepository
{
    Task<StudentTestResult?> GetSemesterTestQuestionsWithAnswers(int? semester, 
        string? track, CancellationToken cancellationToken);

    Task<StudentTestResult?> GetRevisionTestQuestionsWithAnswers(int? year, 
        string? track, CancellationToken cancellationToken);

    Task<ProspectiveStudentTestResult?> GetGeneralTestQuestionsWithAnswers(
        int generalTestId, CancellationToken cancellationToken);

    Task<ErrorOr<Unit>> InsertUserTestAnswers(string userId, int testId, TestType testType,
        List<QuestionAnswer> answers, CancellationToken cancellationToken);
}