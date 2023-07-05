using System.Runtime.InteropServices;

using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Common.Abstractions.Recommendations;
using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;
using CareerOrientation.Application.Tests.StudentTests.Queries.StudentTestsCompletionState;
using CareerOrientation.Domain.Common.DomainErrors;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Recommendations.Queries.StudentRecommendation;

public class UniversityTestsRecommendationHandler 
    : IRequestHandler<UniversityTestsRecommendationQuery, ErrorOr<List<RecommendationResult>>>
{
    private readonly ISender _mediatorSender;
    private readonly IUserRepository _userRepository;
    private readonly ITestsRepository _testsRepository;
    private readonly IPointsCalculationService _pointsCalculationService;

    public UniversityTestsRecommendationHandler(ISender mediatorSender, IUserRepository userRepository,
        ITestsRepository testsRepository, IPointsCalculationService pointsCalculationService)
    {
        _mediatorSender = mediatorSender;
        _userRepository = userRepository;
        _testsRepository = testsRepository;
        _pointsCalculationService = pointsCalculationService;
    }
    
    public async Task<ErrorOr<List<RecommendationResult>>> Handle(UniversityTestsRecommendationQuery request, 
        CancellationToken cancellationToken)
    {
        var student = await _userRepository.GetUniversityStudentById(request.UserId, cancellationToken);
        if (student is null)
        {
            return Errors.User.WrongUserType;
        }

        // First we check if the student has completed all the required tests
        var completionStateQuery = new StudentTestsCompletionStateQuery(request.UserId);
        var errorOrTestsCompletionState = await _mediatorSender.Send(completionStateQuery, cancellationToken);
        if (errorOrTestsCompletionState.IsError)
        {
            return errorOrTestsCompletionState.Errors;
        }
        
        var testsCompletionState = errorOrTestsCompletionState.Value;
        if (testsCompletionState.Any(test => test.IsCompleted == false))
        {
            return Errors.Recommendations.RequiredTestsAreNotCompleted;
        }

        // Now we get the university test ids of the tests that the user has completed
        List<int> universityTestIds = new();

        foreach (var testCompletionResult in testsCompletionState)
        {
            universityTestIds.Add(testCompletionResult.UniversityTestId);
        }
        
        // We collect the users answers to the questions of all of the tests and then the corresponding correct answers
        var userAnswers = await _testsRepository.GetStudentAnswersToUniversityTests(request.UserId,
            universityTestIds, cancellationToken);

        var correctAnswers = await _testsRepository.GetCorrectAnswersOfUniversityTest(
            universityTestIds, cancellationToken);

        // For each question we get the links to relevant tracks, masters degrees and professions
        var questionRecommendationLinks = await _testsRepository
            .GetQuestionsRecommendationLinks(universityTestIds, cancellationToken);

        var recommendationResults = _pointsCalculationService.CreateStudentRecommendations(
            userAnswers, correctAnswers, questionRecommendationLinks);

        return recommendationResults;
    }
}