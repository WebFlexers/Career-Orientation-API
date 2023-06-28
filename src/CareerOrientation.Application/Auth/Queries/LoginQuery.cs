using CareerOrientation.Application.Auth.Common;
using ErrorOr;
using MediatR;

namespace CareerOrientation.Application.Auth.Queries;

public record LoginQuery(
    string? Username,
    string? Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;