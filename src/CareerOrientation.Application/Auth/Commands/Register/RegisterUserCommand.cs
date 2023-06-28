using CareerOrientation.Application.Auth.Common;
using ErrorOr;
using MediatR;

namespace CareerOrientation.Application.Auth.Commands.Register;

public record RegisterUserCommand(
    string Username,
    string Password,
    string ConfirmPassword,
    string Email,
    bool IsProspectiveStudent,
    bool IsGraduate,
    int? Semester,
    string? Track
) : IRequest<ErrorOr<AuthenticationResult>>;