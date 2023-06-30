using CareerOrientation.API.Common.Contracts.Tests.ProspectiveStudentTests;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

namespace CareerOrientation.API.Common.Mapping.Tests.ProspectiveStudentTests;

public static class ProspectiveStudentTestsQuestionsResultMapping
{
    public static ProspectiveStudentTestsQuestionsResponse MapToResponse(this ProspectiveStudentTestResult result)
    {
        return new ProspectiveStudentTestsQuestionsResponse
        (
            GeneralTestId: result.GeneralTestId, 
            Questions: result.Questions
        );
    }
}