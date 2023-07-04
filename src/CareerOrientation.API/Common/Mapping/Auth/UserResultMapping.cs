using CareerOrientation.API.Common.Contracts.Auth;
using CareerOrientation.Application.Auth.Queries.UserById;

namespace CareerOrientation.API.Common.Mapping.Auth;

public static class UserResultMapping
{
    public static UserResponse MapToResponse(this UserResult result)
    {
        return new UserResponse(
            Username: result.Username,
            Email: result.Email,
            IsProspectiveStudent: result.IsProspectiveStudent,
            IsGraduate: result.IsGraduate,
            Semester: result.Semester,
            Track: result.Track
        );
    }
}