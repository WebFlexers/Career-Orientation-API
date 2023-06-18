using Microsoft.Extensions.Logging;

namespace CareerOrientation.Services.Common;

public static partial class ILoggerExtensions
{
    // For more information check: https://youtu.be/a26zu-pyEyg

    #region AuthenticationLogs
    [LoggerMessage(EventId = 0, Level = LogLevel.Information, 
        Message = "Validation for {validationObject} failed")]
    public static partial void LogValidationFail(this ILogger logger, string validationObject);

    [LoggerMessage(EventId = 1, Level = LogLevel.Information, 
    Message = "Successfully inserted user with id: {userId}")]
    public static partial void LogSuccessfulUserInsertion(this ILogger logger, string userId);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, 
    Message = "Successfully assigned role {role} to user with id: {userId}")]
    public static partial void LogSuccessfulRoleAssignment(this ILogger logger, string userId, string role);

    [LoggerMessage(EventId = 3, Level = LogLevel.Error, 
    Message = "Failed to assign a role to user with id: {userId}")]
    public static partial void LogFailedRoleAssignment(this ILogger logger, string userId);

    [LoggerMessage(EventId = 4, Level = LogLevel.Error, 
    Message = "Login attempt with null username and email failed")]
    public static partial void LogNullCredentialsLogin(this ILogger logger);

    [LoggerMessage(EventId = 5, Level = LogLevel.Error, 
    Message = "Authenticating with username {username} and/or email {email} failed")]
    public static partial void LogAuthenticationFailed(this ILogger logger, string? username, string? email);

    [LoggerMessage(EventId = 6, Level = LogLevel.Error, 
    Message = "Login attempt with username {username} and/or email {email} failed, because the user was not found")]
    public static partial void LogUserNotFoundOnLogin(this ILogger logger, string? username, string? email);

    [LoggerMessage(EventId = 7, Level = LogLevel.Information, 
    Message = "Successful login for user with username {username} and/or email {email}!")]
    public static partial void LogSuccessfulLogin(this ILogger logger, string? username, string? email);
    #endregion

    #region Data Access Logs
    [LoggerMessage(EventId = 8, Level = LogLevel.Error, 
        Message = "An error occurred when trying to access the database")]
    public static partial void LogFailedDatabaseOperation(this ILogger logger, Exception ex);

    [LoggerMessage(EventId = 9, Level = LogLevel.Information, 
    Message = "Successully inserted student with id: {userId}")]
    public static partial void LogSuccessfullStudentInsertion(this ILogger logger, string userId);
    #endregion
}
