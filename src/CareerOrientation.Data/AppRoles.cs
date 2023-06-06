namespace CareerOrientation.Data;

public static class AppRoles
{
    public const string Student = nameof(Student);
    public const string ProspectiveStudent = nameof(ProspectiveStudent);

    public static string[] GetAllRoles()
    {
        return new string[] 
        { 
            Student,
            ProspectiveStudent
        };
    }
}
