using Microsoft.Extensions.Logging;

namespace CareerOrientation.Application.Common.Logging;

public static partial class GeneralLogs
{
    [LoggerMessage(EventId = 0, Level = LogLevel.Error, 
        Message = "An unexpected error occurred")]
    public static partial void LogUnexpectedError(this ILogger logger, Exception ex);
}