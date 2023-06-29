using CareerOrientation.API.Common.Contracts.StudentTests;
using CareerOrientation.Application.StudentTests.Common;

namespace CareerOrientation.API.Common.Mapping.StudentTests;

public static class StudentTestsResultMapping
{
    public static StudentTestsQuestionsResponse MapToResponse(this StudentTestResult result)
    {
        return new StudentTestsQuestionsResponse(
            IsRevision: result.IsRevision,
            UniversityTestId: result.UniversityTestId,
            Questions: result.Questions);
    } 
}