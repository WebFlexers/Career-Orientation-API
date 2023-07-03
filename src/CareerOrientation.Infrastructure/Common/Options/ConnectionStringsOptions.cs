namespace CareerOrientation.Infrastructure.Common.Options;

public class ConnectionStringsOptions
{
    public const string SectionName = "ConnectionStrings";

    public required string Default { get; init; }
    public required string LoggingDb { get; init; }
}