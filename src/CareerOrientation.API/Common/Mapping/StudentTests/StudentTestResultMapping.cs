using CareerOrientation.API.Common.Contracts.StudentTests;
using CareerOrientation.Application.StudentTests.Common;

namespace CareerOrientation.API.Common.Mapping.StudentTests;

public static class StudentTestResultMapping
{
    public static StudentTestQuestionsResponse MapToResponse(this StudentTestResult result)
    {
        return new StudentTestQuestionsResponse (
            result.IsRevision,
            result.UniversityTestId,
            result.Questions
        );
    } 
}