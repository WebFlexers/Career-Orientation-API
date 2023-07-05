using CareerOrientation.Domain.Common.Enums;

namespace CareerOrientation.API.Common.Contracts.Recommendations;

public record RecommendationResponse(
    RecommendationLevel RecommendationLevel,
    string Name,
    int PercentageScore);