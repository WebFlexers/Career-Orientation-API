namespace CareerOrientation.API.Common.Contracts.Auth;

public record UserResponse(
    string Username,
    string Email,
    bool IsProspectiveStudent,
    bool IsGraduate,
    int? Semester,
    string? Track
);