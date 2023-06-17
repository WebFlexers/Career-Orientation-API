namespace CareerOrientation.Services.Validation.Auth;

public static class UserErrorCodes
{
    public const string UserIdentifierRequired = nameof(UserIdentifierRequired);
    public const string PasswordRequired = nameof(PasswordRequired);
    public const string PasswordVerificationRequired = nameof(PasswordVerificationRequired);
    public const string InvalidPasswordVerification = nameof(InvalidPasswordVerification);
    public const string InvalidSemester = nameof(InvalidSemester);
    public const string InvalidTrack = nameof(InvalidTrack);
    public const string InvalidUserType = nameof(InvalidUserType);
}
