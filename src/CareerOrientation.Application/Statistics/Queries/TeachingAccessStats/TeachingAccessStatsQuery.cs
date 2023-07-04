using CareerOrientation.Application.Statistics.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Statistics.Queries.TeachingAccessStats;

public record TeachingAccessStatsQuery(
    string UserId) : IRequest<ErrorOr<List<TeachingAccessStatResult>>>;