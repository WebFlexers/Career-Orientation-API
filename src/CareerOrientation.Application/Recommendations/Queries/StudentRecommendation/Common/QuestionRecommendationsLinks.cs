using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;

/// <summary>
/// Stores the associated tracks, professions and masters degrees of the question
/// </summary>
public record QuestionRecommendationsLinks(
    int QuestionId,
    List<Track> Tracks,
    List<Profession> Professions,
    List<MastersDegree> MastersDegrees);