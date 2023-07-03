using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Statistics.Common;
using CareerOrientation.Domain.Common.DomainErrors;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Statistics.Queries;

public class GetTeachingAccessStatsHandler : 
    IRequestHandler<GetTeachingAccessStatsQuery, ErrorOr<List<TeachingAccessStatResult>>>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public GetTeachingAccessStatsHandler(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }
    
    public async Task<ErrorOr<List<TeachingAccessStatResult>>> Handle(GetTeachingAccessStatsQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _statisticsRepository
            .GetUserTeachingAccessStats(request.UserId, cancellationToken);

        return result;
    }
}