using CareerOrientation.Application.Common.Models;

namespace CareerOrientation.API.Common.Contracts.StudentTests;

public record StudentTestsQuestionsResponse(
    bool IsRevision,
    int UniversityTestId,
    List<TestQuestionResult> Questions);