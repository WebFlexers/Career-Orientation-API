using CareerOrientation.Application.Tests.StudentTests.Common;

namespace CareerOrientation.Application.Tests.Common;

public interface ISubmitTestCommand
{
    string UserId { get; init; }
    List<UserQuestionAnswer> Answers { get; init; }
}