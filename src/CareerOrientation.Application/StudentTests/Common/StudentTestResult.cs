using CareerOrientation.Application.Common.Models;

namespace CareerOrientation.Application.StudentTests.Common;

public record StudentTestResult(
    bool IsRevision,
    int UniversityTestId,
    List<TestQuestionResult> Questions);