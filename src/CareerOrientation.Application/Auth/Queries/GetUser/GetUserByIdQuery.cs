using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Auth.Queries.GetUser;

public record GetUserByIdQuery(string UserId) : IRequest<ErrorOr<UserResult>>;