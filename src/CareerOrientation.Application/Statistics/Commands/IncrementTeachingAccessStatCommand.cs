using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Statistics.Commands;

public record IncrementTeachingAccessStatCommand(
    string UserId,
    int Semester) : IRequest<ErrorOr<Unit>>;