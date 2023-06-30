using CareerOrientation.Application.Common.Models;

namespace CareerOrientation.Application.Tests.StudentTests.Common;

public record StudentTestResult(
    bool IsRevision,
    int UniversityTestId,
    List<ITestQuestionResult?> Questions);