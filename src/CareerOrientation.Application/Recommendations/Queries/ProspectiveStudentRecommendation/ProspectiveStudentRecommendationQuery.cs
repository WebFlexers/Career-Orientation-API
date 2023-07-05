using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Recommendations.Queries.ProspectiveStudentRecommendation;

public record ProspectiveStudentRecommendationQuery(
    string UserId) : IRequest<ErrorOr<List<GeneralTestRecommendationResult>>>;