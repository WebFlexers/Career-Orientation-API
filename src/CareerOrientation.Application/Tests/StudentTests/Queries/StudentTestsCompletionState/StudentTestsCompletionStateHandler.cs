using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.StudentTestsCompletionState;

public class StudentTestsCompletionStateHandler
    : IRequestHandler<StudentTestsCompletionStateQuery, ErrorOr<List<IUniversityTestCompletionResult>>>
{
    private readonly ITestsRepository _testsRepository;

    public StudentTestsCompletionStateHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<List<IUniversityTestCompletionResult>>> Handle(StudentTestsCompletionStateQuery request, 
        CancellationToken cancellationToken)
    {
        var testCompletionState = await _testsRepository
            .GetStudentTestsCompletionState(request.UserId, cancellationToken);

        return testCompletionState;
    }
}