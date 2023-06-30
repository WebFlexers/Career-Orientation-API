using CareerOrientation.API.Common.Contracts.Tests.StudentTests;
using CareerOrientation.Application.Tests.StudentTests.Common;

namespace CareerOrientation.API.Common.Mapping.Tests.StudentTests;

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