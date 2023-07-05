using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Recommendations.Queries.StudentRecommendation;

/// <summary>
/// Creates recommendations for tracks, masters degrees and professions, from the results of the tests
/// </summary>
public record UniversityTestsRecommendationQuery(
    string UserId) : IRequest<ErrorOr<List<RecommendationResult>>>;