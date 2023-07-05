using System.Runtime.InteropServices;

using CareerOrientation.API.Common.Contracts.Recommendations;
using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;

namespace CareerOrientation.API.Common.Mapping.Recommendations;

public static class RecommendationResultMapping
{
    public static RecommendationResponse MapToRecommendationResponse(this RecommendationResult result)
    {
        return new RecommendationResponse(result.RecommendationLevel, result.Name, result.PercentageScore);
    }
    
    public static StudentRecommendationsResponse MapToStudentRecommendationsResponse(
        this List<RecommendationResult> recommendationResults)
    {
        var recommendations = new Dictionary<RecommendationType, List<RecommendationResponse>>();

        foreach (RecommendationResult result in recommendationResults
                     .OrderBy(result => result.RecommendationType)
                     .ThenByDescending(result => result.PercentageScore))
        {
            if (recommendations.TryGetValue(result.RecommendationType, out List<RecommendationResponse>? recommendation))
            {
                recommendation.Add(result.MapToRecommendationResponse());
            }
            else
            {
                recommendations.Add(result.RecommendationType, new List<RecommendationResponse>
                {
                    result.MapToRecommendationResponse()
                });
            }
        }

        return new StudentRecommendationsResponse(recommendations);
    }
}