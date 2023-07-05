using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;
using CareerOrientation.Application.Tests.Common;
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

    Task<ErrorOr<List<IUniversityTestCompletionResult>>> GetStudentTestsCompletionState(string userId, 
        CancellationToken cancellationToken);

    Task<ErrorOr<List<GeneralTestCompletionResult>>> GetProspectiveStudentTestsCompletionState(string userId,
        CancellationToken cancellationToken);

    Task<List<IQuestionAnswer>> GetUserAnswersToGeneralTest(string userId, int generalTestId,
        CancellationToken cancellationToken);

    Task<List<IQuestionAnswer>> GetStudentAnswersToUniversityTests(string userId,
        List<int> universityTestIds, CancellationToken cancellationToken);
    
    Task<List<IQuestionAnswer>> GetCorrectAnswersOfUniversityTest(List<int> universityTestIds,
        CancellationToken cancellationToken);

    Task<List<IQuestionAnswer>> GetCorrectAnswersOfGeneralTest(int generalTestId, CancellationToken cancellationToken);
    
    Task<ErrorOr<Unit>> InsertUserTestAnswers(
        string userId,
        int testId, 
        TestType testType,
        List<UserQuestionAnswer> answers, 
        CancellationToken cancellationToken);

    Task<List<QuestionRecommendationsLinks>> GetQuestionsRecommendationLinks(List<int> universityTestIds,
        CancellationToken cancellationToken);
    
    Task<ErrorOr<Unit>> EnsureUserHasntTakenTest(string userId, int testId, TestType testType,
        CancellationToken cancellationToken);
}