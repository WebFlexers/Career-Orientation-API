using CareerOrientation.API.Common.Contracts.Tests.StudentTests;
using CareerOrientation.Application.Tests.StudentTests.Commands.SubmitTestAnswers;

namespace CareerOrientation.API.Common.Mapping.Tests.StudentTests;

public static class StudentTestSubmissionRequestMapping
{
    public static SubmitStudentTestAnswersCommand MapToCommand(this StudentTestSubmissionRequest request)
    {
        return new SubmitStudentTestAnswersCommand(
            request.UserId,
            request.UniversityTestId,
            request.Answers.ConvertAll(answer => answer.MapToQuestionAnswer()));
    }
}