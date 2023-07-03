using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.GetStudentTestsCompletionState;

public class GetStudentTestsCompletionStateHandler
    : IRequestHandler<GetStudentTestsCompletionStateQuery, ErrorOr<List<IUniversityTestCompletionResult>>>
{
    private readonly ITestsRepository _testsRepository;

    public GetStudentTestsCompletionStateHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<List<IUniversityTestCompletionResult>>> Handle(GetStudentTestsCompletionStateQuery request, 
        CancellationToken cancellationToken)
    {
        var testCompletionState = await _testsRepository
            .GetStudentTestsCompletionState(request.UserId, cancellationToken);

        return testCompletionState;
    }
}