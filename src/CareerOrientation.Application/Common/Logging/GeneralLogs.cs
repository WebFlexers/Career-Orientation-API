using ErrorOr;

using Microsoft.Extensions.Logging;

namespace CareerOrientation.Application.Common.Logging;

public static partial class GeneralLogs
{
    [LoggerMessage(EventId = 0, Level = LogLevel.Error, 
        Message = "An unexpected error occurred")]
    public static partial void LogUnexpectedError(this ILogger logger, Exception ex);

    [LoggerMessage(EventId = 1, Level = LogLevel.Information,
        Message = "Error {errorCode} occurred when executing request {requestName}: {errorDescription}")]
    public static partial void LogGeneralExpectedError(this ILogger logger, string requestName, string errorCode, 
        string errorDescription);
}