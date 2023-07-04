using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Commands.SubmitTestAnswersCommand;

public record SubmitProspectiveStudentTestAnswersCommand(
    string UserId,
    int GeneralTestId,
    List<QuestionAnswer> Answers) : IRequest<ErrorOr<bool>>, ISubmitTestCommand;