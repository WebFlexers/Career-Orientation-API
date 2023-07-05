using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;
using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Domain.Common.Enums;

namespace CareerOrientation.Application.Common.Abstractions.Recommendations;

public interface IPointsCalculationService
{
    float CalculateGeneralTestMaxPoints(List<IQuestionAnswer> userAnswers);
    float CalculateProspectiveStudentPoints(List<IQuestionAnswer> userAnswers, List<IQuestionAnswer> correctAnswers);
    List<RecommendationResult> CreateStudentRecommendations(List<IQuestionAnswer> userAnswers,
        List<IQuestionAnswer> correctAnswers, List<QuestionRecommendationsLinks> questionRecommendationsLinks,
        int semester);
    RecommendationLevel GetRecommendationLevel(int userPointsPercentage);
}