namespace CareerOrientation.Application.Auth.Queries.UserById;

public record UserResult(
    string Username,
    string Email,
    bool IsProspectiveStudent,
    bool IsGraduate,
    int? Semester,
    string? Track
);