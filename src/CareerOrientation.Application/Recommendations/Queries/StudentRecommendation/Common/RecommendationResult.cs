using CareerOrientation.Domain.Common.Enums;

namespace CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;

public record RecommendationResult(
    RecommendationType RecommendationType,
    RecommendationLevel RecommendationLevel,
    string Name,
    int PercentageScore);

