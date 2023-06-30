using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Tests.StudentTests.Common.Mapping;

public static class UniversityTestMapping
{
    public static StudentTestResult MapToStudentTestResult(this UniversityTest test)
    {
        return new StudentTestResult(
            IsRevision: test.IsRevision,
            UniversityTestId: test.UniversityTestId,
            Questions: test.Questions.ConvertAll(q => q.MapToTestQuestionResult()));
    }
}