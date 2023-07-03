using CareerOrientation.Application.Common.Abstractions.Persistence;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Statistics.Commands;

public class IncrementTeachingAccessStatHandler : IRequestHandler<IncrementTeachingAccessStatCommand, ErrorOr<Unit>>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public IncrementTeachingAccessStatHandler(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }
    
    public async Task<ErrorOr<Unit>> Handle(IncrementTeachingAccessStatCommand command, CancellationToken cancellationToken)
    {
        await _statisticsRepository.IncrementSemesterTeachingAccessStat(command.UserId, command.Semester,
            cancellationToken);

        return Unit.Value;
    }
}