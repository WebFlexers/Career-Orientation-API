using CareerOrientation.Application.Common.Abstractions.Services;

namespace CareerOrientation.Infrastructure.Services;

public class Clock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}