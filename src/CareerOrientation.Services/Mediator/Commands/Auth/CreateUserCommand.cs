using CareerOrientation.Data.DTOs;
using CareerOrientation.Data.DTOs.Auth;
using LanguageExt.Common;
using MediatR;

namespace CareerOrientation.Services.Mediator.Commands.Auth;

public record CreateUserCommand(CreateUserRequest CreateUserRequest) : IRequest<Result<AuthenticationResponse>>;