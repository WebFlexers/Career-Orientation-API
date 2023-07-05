using CareerOrientation.API.Common.Contracts.Recommendations;
using CareerOrientation.Application.Recommendations.Queries.ProspectiveStudentRecommendation;

namespace CareerOrientation.API.Common.Mapping.Recommendations;

public static class GeneralTestRecommendationResultMapping
{
    public static GeneralTestRecommendationResponse MapToResponse(this GeneralTestRecommendationResult result)
    {
        return new GeneralTestRecommendationResponse(
            result.GeneralTestType,
            result.RecommendationLevel,
            result.PercentageScore,
            result.RecommendationMessage);
    }
}