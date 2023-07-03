namespace CareerOrientation.Application.Tests.StudentTests.Common;

public interface IUniversityTestCompletionResult
{
    int UniversityTestId { get; init; }
    bool IsCompleted { get; init; }
}