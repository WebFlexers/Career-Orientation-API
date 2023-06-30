using CareerOrientation.Application.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.StudentTests.Commands.SubmitTestAnswers;

public record SubmitTestAnswersCommand(
    string UserId,
    int UniversityTestId,
    List<QuestionAnswer> Answers) : IRequest<ErrorOr<Unit>>;