using CareerOrientation.Application.Recommendations.Common;
using CareerOrientation.Domain.Entities.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Recommendations.Queries.ProspectiveStudentRecommendation;

public record GeneralTestRecommendationQuery(
    string UserId,
    int GeneralTestId,
    GeneralTestType TestType) : IRequest<ErrorOr<GeneralTestRecommendationResult>>;