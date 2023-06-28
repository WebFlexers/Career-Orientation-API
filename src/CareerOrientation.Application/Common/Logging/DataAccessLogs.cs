using Microsoft.Extensions.Logging;

namespace CareerOrientation.Application.Common.Logging;

public static partial class DataAccessLogs
{
    [LoggerMessage(EventId = 2000, Level = LogLevel.Error, 
        Message = "An error occurred when trying to access the database")]
    public static partial void LogFailedDatabaseOperation(this ILogger logger, Exception ex);
}