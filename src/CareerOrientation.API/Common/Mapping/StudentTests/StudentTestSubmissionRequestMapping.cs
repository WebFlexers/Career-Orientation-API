using CareerOrientation.API.Common.Contracts.StudentTests;
using CareerOrientation.Application.StudentTests.Commands.SubmitTestAnswers;

namespace CareerOrientation.API.Common.Mapping.StudentTests;

public static class StudentTestSubmissionRequestMapping
{
    public static SubmitTestAnswersCommand MapToCommand(this StudentTestSubmissionRequest request)
    {
        return new SubmitTestAnswersCommand(
            request.UserId,
            request.UniversityTestId,
            request.Answers.ConvertAll(answer => answer.MapToQuestionAnswer()));
    }
}