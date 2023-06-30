using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Commands.SubmitTestAnswersCommand;

public class SubmitProspectiveStudentTestAnswersHandler 
    : IRequestHandler<SubmitProspectiveStudentTestAnswersCommand, ErrorOr<Unit>>
{
    private readonly ITestsRepository _testsRepository;
    private readonly IUserRepository _userRepository;

    public SubmitProspectiveStudentTestAnswersHandler(ITestsRepository testsRepository, IUserRepository userRepository)
    {
        _testsRepository = testsRepository;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<Unit>> Handle(SubmitProspectiveStudentTestAnswersCommand command, 
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(command.UserId, cancellationToken);
        if (user is null)
        {
            return Errors.User.UserNotFoundById;
        }
        if (user.IsProspectiveStudent == false)
        {
            return Errors.User.WrongUserType;
        }
        
        var result = await _testsRepository.InsertUserTestAnswers(
            command.UserId, 
            command.GeneralTestId,
            TestType.GeneralTest, 
            command.Answers, 
            cancellationToken);

        return result;
    }
}