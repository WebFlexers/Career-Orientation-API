using CareerOrientation.API.Common.Contracts.Tests.ProspectiveStudentTests;
using CareerOrientation.API.Common.Mapping.Tests.StudentTests;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Commands.SubmitTestAnswersCommand;

namespace CareerOrientation.API.Common.Mapping.Tests.ProspectiveStudentTests;

public static class ProspectiveStudentTestsSubmissionRequestMapping
{
    public static SubmitProspectiveStudentTestAnswersCommand MapToCommand(
        this ProspectiveStudentTestsSubmissionRequest request)
    {
        return new SubmitProspectiveStudentTestAnswersCommand(
            request.UserId,
            request.GeneralTestId,
            request.Answers.ConvertAll(answer => answer.MapToQuestionAnswer()));
    }
}