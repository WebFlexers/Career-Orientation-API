using CareerOrientation.Domain.Common.UserMessages;

namespace CareerOrientation.Domain.Common.Enums.Mappings;

public static class RecommendationLevelsMapping
{
    public static string MapToComputerScienceRecommendationMessage(this RecommendationLevel recommendationLevel)
    {
        return recommendationLevel switch
        {
            RecommendationLevel.VeryPoorFit => InformaticsRecommendationMessages.VeryPoorFit,
            RecommendationLevel.PoorFit => InformaticsRecommendationMessages.PoorFit,
            RecommendationLevel.ModerateFit => InformaticsRecommendationMessages.ModerateFit,
            RecommendationLevel.GoodFit => InformaticsRecommendationMessages.GoodFit,
            RecommendationLevel.ExcellentFit => InformaticsRecommendationMessages.ExcellentFit,
            _ => string.Empty
        };
    }

    public static string MapToUniversityOfPiraeusRecommendationMessage(this RecommendationLevel recommendationLevel)
    {
        return recommendationLevel switch
        {
            RecommendationLevel.VeryPoorFit => UniversityOfPiraeusRecommendationMessages.VeryPoorFit,
            RecommendationLevel.PoorFit => UniversityOfPiraeusRecommendationMessages.PoorFit,
            RecommendationLevel.ModerateFit => UniversityOfPiraeusRecommendationMessages.ModerateFit,
            RecommendationLevel.GoodFit => UniversityOfPiraeusRecommendationMessages.GoodFit,
            RecommendationLevel.ExcellentFit => UniversityOfPiraeusRecommendationMessages.ExcellentFit,
            _ => string.Empty
        };
    }
}