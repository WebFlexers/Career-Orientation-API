using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Commands.SubmitTestAnswers;

public record SubmitStudentTestAnswersCommand(
    string UserId,
    int UniversityTestId,
    List<QuestionAnswer> Answers) : IRequest<ErrorOr<bool>>, ISubmitTestCommand;