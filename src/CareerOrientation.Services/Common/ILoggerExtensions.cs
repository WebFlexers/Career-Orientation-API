using Microsoft.Extensions.Logging;

namespace CareerOrientation.Services.Common;

public static partial class ILoggerExtensions
{
    // For more information check: https://youtu.be/a26zu-pyEyg

    [LoggerMessage(EventId = 0, Level = LogLevel.Information, 
        Message = "Validation for {validationObject} failed")]
    public static partial void LogValidationFail(this ILogger logger, string validationObject);

    [LoggerMessage(EventId = 1, Level = LogLevel.Information, 
    Message = "Successfully inserted user with id: {userId}")]
    public static partial void LogSuccessfulUserInsertion(this ILogger logger, string userId);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, 
    Message = "Successfully assigned role {role} to user with id: {userId}")]
    public static partial void LogSuccessfulRoleAssignment(this ILogger logger, string userId, string role);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information, 
    Message = "Failed to assign a role to user with id: {userId}")]
    public static partial void LogFailedRoleAssignment(this ILogger logger, string userId);
}
