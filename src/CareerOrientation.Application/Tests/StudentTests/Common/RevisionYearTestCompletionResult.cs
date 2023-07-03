namespace CareerOrientation.Application.Tests.StudentTests.Common;

public record RevisionYearTestCompletionResult(
    int UniversityTestId,
    int RevisionYear,
    bool IsCompleted) : IUniversityTestCompletionResult;