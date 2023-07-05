using CareerOrientation.Domain.Common.Enums;
using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.API.Common.Contracts.Recommendations;

public record GeneralTestRecommendationResponse(
    GeneralTestType GeneralTestType,
    RecommendationLevel RecommendationLevel,
    int PercentageScore,
    string RecommendationMessage);