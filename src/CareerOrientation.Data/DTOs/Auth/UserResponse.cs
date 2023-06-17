namespace CareerOrientation.Data.DTOs.Auth;

public class UserResponse
{
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsProspectiveStudent { get; set; }
    public bool IsGraduate { get; set; }
    public int? Semester { get; set; }
    public string? Track { get; set; }

    public UserResponse(string username, string email, bool isProspectiveStudent, bool isGraduate, int? semester, string? track)
    {
        Username = username;
        Email = email;
        IsProspectiveStudent = isProspectiveStudent;
        IsGraduate = isGraduate;
        Semester = semester;
        Track = track;
    }
}
