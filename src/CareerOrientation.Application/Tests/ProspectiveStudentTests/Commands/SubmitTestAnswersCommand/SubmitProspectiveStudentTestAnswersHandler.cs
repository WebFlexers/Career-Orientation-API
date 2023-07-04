using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsCompletionState;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsQuestions;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Commands.SubmitTestAnswersCommand;

public class SubmitProspectiveStudentTestAnswersHandler 
    : IRequestHandler<SubmitProspectiveStudentTestAnswersCommand, ErrorOr<bool>>
{
    private readonly ITestsRepository _testsRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISender _mediatorSender;

    public SubmitProspectiveStudentTestAnswersHandler(ITestsRepository testsRepository, IUserRepository userRepository,
        ISender mediatorSender)
    {
        _testsRepository = testsRepository;
        _userRepository = userRepository;
        _mediatorSender = mediatorSender;
    }
    
    public async Task<ErrorOr<bool>> Handle(SubmitProspectiveStudentTestAnswersCommand command, 
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

        if (result.IsError)
        {
            return result.Errors;
        }

        var query = new GetProspectiveStudentTestsCompletionStateQuery(command.UserId);
        var completionState = await _mediatorSender.Send(query, cancellationToken);

        if (completionState.IsError)
        {
            return completionState.Errors;
        }
        
        // If all the tests are complete the user can proceed to the recommendations
        return completionState.Value.All(completionResult => completionResult.IsCompleted);
    }
}