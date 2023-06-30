using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.StudentTests.Commands.SubmitTestAnswers;

public class SubmitTestAnswersHandler : IRequestHandler<SubmitTestAnswersCommand, ErrorOr<Unit>>
{
    private readonly ITestsRepository _testsRepository;

    public SubmitTestAnswersHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<Unit>> Handle(SubmitTestAnswersCommand command, CancellationToken cancellationToken)
    {
        var result = await _testsRepository.InsertUserTestAnswers(
            command.UserId, 
            command.UniversityTestId,
            TestType.UniversityTest, 
            command.Answers, 
            cancellationToken);

        return result;
    }
}