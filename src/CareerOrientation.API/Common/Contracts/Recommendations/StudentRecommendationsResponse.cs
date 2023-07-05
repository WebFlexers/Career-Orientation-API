using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;

namespace CareerOrientation.API.Common.Contracts.Recommendations;

public record StudentRecommendationsResponse(
    Dictionary<RecommendationType, List<RecommendationResponse>> Recommendations);