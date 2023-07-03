using CareerOrientation.Application.Statistics.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Statistics.Queries;

public record GetTeachingAccessStatsQuery(
    string UserId) : IRequest<ErrorOr<List<TeachingAccessStatResult>>>;