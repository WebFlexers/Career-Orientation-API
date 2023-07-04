using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Statistics.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Statistics.Queries.TeachingAccessStats;

public class TeachingAccessStatsHandler : 
    IRequestHandler<TeachingAccessStatsQuery, ErrorOr<List<TeachingAccessStatResult>>>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public TeachingAccessStatsHandler(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }
    
    public async Task<ErrorOr<List<TeachingAccessStatResult>>> Handle(TeachingAccessStatsQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _statisticsRepository
            .GetUserTeachingAccessStats(request.UserId, cancellationToken);

        return result;
    }
}