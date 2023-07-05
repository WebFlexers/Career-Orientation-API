using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Common.Abstractions.Recommendations;
using CareerOrientation.Domain.Common.Enums.Mappings;
using CareerOrientation.Domain.Entities.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Recommendations.Queries.ProspectiveStudentRecommendation;

public class GeneralTestRecommendationHandler 
    : IRequestHandler<GeneralTestRecommendationQuery, ErrorOr<GeneralTestRecommendationResult>>
{
    private readonly ITestsRepository _testsRepository;
    private readonly IPointsCalculationService _pointsCalculationService;

    public GeneralTestRecommendationHandler(ITestsRepository testsRepository, 
        IPointsCalculationService pointsCalculationService)
    {
        _testsRepository = testsRepository;
        _pointsCalculationService = pointsCalculationService;
    }
    
    public async Task<ErrorOr<GeneralTestRecommendationResult>> Handle(GeneralTestRecommendationQuery request, 
        CancellationToken cancellationToken)
    {
        var userAnswers = await _testsRepository.GetUserAnswersToGeneralTest(request.UserId,
            request.GeneralTestId, cancellationToken);

        var correctAnswers = await _testsRepository.GetCorrectAnswersOfGeneralTest(
            request.GeneralTestId, cancellationToken);

        float maxPoints = _pointsCalculationService.CalculateGeneralTestMaxPoints(userAnswers);
        float userPoints = _pointsCalculationService.CalculateProspectiveStudentPoints(userAnswers, correctAnswers);

        var userPointsPercentage = (int)Math.Round((userPoints / maxPoints) * 100);

        var recommendationLevel = _pointsCalculationService.GetRecommendationLevel(userPointsPercentage);
        
        string recommendationMessage = request.TestType == GeneralTestType.ComputerScienceSuitability 
            ? recommendationLevel.MapToComputerScienceRecommendationMessage() 
            : recommendationLevel.MapToUniversityOfPiraeusRecommendationMessage();

        return new GeneralTestRecommendationResult(
            request.TestType,
            recommendationLevel,
            userPointsPercentage,
            recommendationMessage);
    }
}