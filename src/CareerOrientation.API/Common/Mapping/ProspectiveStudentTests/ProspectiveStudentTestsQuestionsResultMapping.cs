using CareerOrientation.API.Common.Contracts.ProspectiveStudentTests;
using CareerOrientation.Application.ProspectiveStudentTests.Common;

namespace CareerOrientation.API.Common.Mapping.ProspectiveStudentTests;

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