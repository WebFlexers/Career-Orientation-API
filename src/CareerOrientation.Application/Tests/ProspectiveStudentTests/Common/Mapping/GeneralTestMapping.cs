using CareerOrientation.Application.Tests.StudentTests.Common.Mapping;
using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Common.Mapping;

public static class GeneralTestMapping
{
    public static ProspectiveStudentTestResult MapToProspectiveStudentTestResult(this GeneralTest test)
    {
        return new ProspectiveStudentTestResult(
            GeneralTestId: test.GeneralTestId,
            Questions: test.Questions.ConvertAll(q => q.MapToTestQuestionResult()));
    }
}