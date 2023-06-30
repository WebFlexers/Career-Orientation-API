using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Commands.SubmitTestAnswers;

public class SubmitStudentTestAnswersHandler : IRequestHandler<SubmitStudentTestAnswersCommand, ErrorOr<Unit>>
{
    private readonly ITestsRepository _testsRepository;
    private readonly IUserRepository _userRepository;

    public SubmitStudentTestAnswersHandler(ITestsRepository testsRepository, IUserRepository userRepository)
    {
        _testsRepository = testsRepository;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<Unit>> Handle(SubmitStudentTestAnswersCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(command.UserId, cancellationToken);
        if (user is null)
        {
            return Errors.User.UserNotFoundById;
        }
        if (user.IsProspectiveStudent)
        {
            return Errors.User.WrongUserType;
        }

        var result = await _testsRepository.InsertUserTestAnswers(
            command.UserId, 
            command.UniversityTestId,
            TestType.UniversityTest, 
            command.Answers, 
            cancellationToken);

        return result;
    }
}