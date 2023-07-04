using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Domain.Common.Enums;

namespace CareerOrientation.Application.Common.Abstractions.Recommendations;

public interface IPointsCalculationService
{
    float CalculateMaxPoints(List<IQuestionAnswer> userAnswers);
    float CalculateUserPoints(List<IQuestionAnswer> userAnswers, List<IQuestionAnswer> correctAnswers);
    RecommendationLevel GetRecommendationLevel(int userPointsPercentage);
}