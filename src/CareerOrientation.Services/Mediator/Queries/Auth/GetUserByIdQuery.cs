using CareerOrientation.Data.DTOs.Auth;
using LanguageExt.Common;
using MediatR;

namespace CareerOrientation.Services.Mediator.Queries.Auth;

public record GetUserByIdQuery(string UserId) : IRequest<Result<UserResponse>>;
