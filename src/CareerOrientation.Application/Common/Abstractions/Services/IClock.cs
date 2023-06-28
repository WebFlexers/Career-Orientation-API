namespace CareerOrientation.Application.Common.Abstractions.Services;

public interface IClock
{
    DateTime UtcNow { get; }
}