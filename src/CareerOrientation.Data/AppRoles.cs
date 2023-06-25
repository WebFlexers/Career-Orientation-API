namespace CareerOrientation.Data;

public static class AppRoles
{
    public const string Student = nameof(Student);
    public const string GraduateStudent = nameof(GraduateStudent);
    public const string ProspectiveStudent = nameof(ProspectiveStudent);

    public static string[] GetAllRoles()
    {
        return new string[] 
        { 
            Student,
            GraduateStudent,
            ProspectiveStudent
        };
    }
}