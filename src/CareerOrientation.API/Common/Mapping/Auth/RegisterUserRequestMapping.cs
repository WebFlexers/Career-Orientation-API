using CareerOrientation.API.Common.Contracts.Auth;
using CareerOrientation.Application.Auth.Commands.Register;

namespace CareerOrientation.API.Common.Mapping.Auth;

public static class RegisterUserRequestMapping
{
    public static RegisterUserCommand MapToRegisterUserCommand(this RegisterUserRequest request)
    {
        return new RegisterUserCommand(
            Username: request.Username,
            Password: request.Password,
            ConfirmPassword: request.ConfirmPassword,
            Email: request.Email,
            IsProspectiveStudent: request.IsGraduate,
            IsGraduate: request.IsGraduate,
            Semester: request.Semester,
            Track: request.Track);
    }
}