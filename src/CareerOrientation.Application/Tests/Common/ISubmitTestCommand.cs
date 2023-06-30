using CareerOrientation.Application.Tests.StudentTests.Common;

using MediatR;

namespace CareerOrientation.Application.Tests.Common;

public interface ISubmitTestCommand
{
    string UserId { get; init; }
    List<QuestionAnswer> Answers { get; init; }
}