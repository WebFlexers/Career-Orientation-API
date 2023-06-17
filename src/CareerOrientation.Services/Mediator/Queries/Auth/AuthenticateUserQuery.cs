using CareerOrientation.Data.DTOs.Auth;
using LanguageExt.Common;
using MediatR;

namespace CareerOrientation.Services.Mediator.Queries.Auth;

public record AuthenticateUserQuery(AuthenticationRequest AuthRequest) : IRequest<Result<AuthenticationResponse>>;
