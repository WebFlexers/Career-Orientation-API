namespace CareerOrientation.API.Common.Contracts.Auth;

public record RegisterUserRequest(
    string Username,
    string Password,
    string ConfirmPassword,
    string Email,
    bool IsProspectiveStudent,
    bool IsGraduate,
    int? Semester,
    string? Track);