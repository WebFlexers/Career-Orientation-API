namespace CareerOrientation.Application.Tests.StudentTests.Common;

public record SemesterUniversityTestCompletionResult(
    int UniversityTestId,
    int Semester,
    bool IsCompleted) : IUniversityTestCompletionResult;