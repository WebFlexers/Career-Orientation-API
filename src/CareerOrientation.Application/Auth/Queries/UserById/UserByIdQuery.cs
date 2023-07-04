using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Auth.Queries.UserById;

public record UserByIdQuery(string UserId) : IRequest<ErrorOr<UserResult>>;