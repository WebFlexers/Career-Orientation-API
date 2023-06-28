using Microsoft.Extensions.Logging;

namespace CareerOrientation.Application.Common.Logging;

public static partial class AuthenticationLogs
{

    [LoggerMessage(EventId = 1000, Level = LogLevel.Information, 
        Message = "Successfully inserted user with id: {userId} and role: {role}")]
    public static partial void LogSuccessfulUserInsertion(this ILogger logger, string userId, string role);

    [LoggerMessage(EventId = 1002, Level = LogLevel.Error, 
        Message = "Failed to assign a role {role} to user")]
    public static partial void LogFailedRoleAssignment(this ILogger logger, string role);

    [LoggerMessage(EventId = 1004, Level = LogLevel.Warning, 
        Message = "Authenticating with username {username} and/or email {email} failed")]
    public static partial void LogAuthenticationFailed(this ILogger logger, string? username, string? email);

    [LoggerMessage(EventId = 1006, Level = LogLevel.Information, 
        Message = "Successful login for user with username {username} and/or email {email}!")]
    public static partial void LogSuccessfulLogin(this ILogger logger, string? username, string? email);
}