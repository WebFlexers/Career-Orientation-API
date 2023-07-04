using CareerOrientation.Domain.Common.Enums;
using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Application.Recommendations.Common;

public record GeneralTestRecommendationResult(
    GeneralTestType GeneralTestType,
    RecommendationLevel RecommendationLevel,
    int PercentageScore,
    string RecommendationMessage);