using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.StudentTests.Queries.StudentTestsCompletionState;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Commands.SubmitTestAnswers;

public class SubmitStudentTestAnswersHandler : IRequestHandler<SubmitStudentTestAnswersCommand, ErrorOr<bool>>
{
    private readonly ITestsRepository _testsRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISender _mediatorSender;

    public SubmitStudentTestAnswersHandler(ITestsRepository testsRepository, IUserRepository userRepository,
        ISender mediatorSender)
    {
        _testsRepository = testsRepository;
        _userRepository = userRepository;
        _mediatorSender = mediatorSender;
    }
    
    public async Task<ErrorOr<bool>> Handle(SubmitStudentTestAnswersCommand command, CancellationToken cancellationToken)
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

        if (result.IsError)
        {
            return result.Errors;
        }

        var query = new StudentTestsCompletionStateQuery(command.UserId);
        var completionState = await _mediatorSender.Send(query, cancellationToken);

        if (completionState.IsError)
        {
            return completionState.Errors;
        }
        
        // If all the tests are complete the user can proceed to the recommendations
        return completionState.Value.All(completionResult => completionResult.IsCompleted);
    }
}