using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Commands.SubmitTestAnswers;

/// <summary>
/// Submits the test answers of the students and returns whether the student has submitted all the required tests 
/// </summary>
public record SubmitStudentTestAnswersCommand(
    string UserId,
    int UniversityTestId,
    List<UserQuestionAnswer> Answers) : IRequest<ErrorOr<bool>>, ISubmitTestCommand;