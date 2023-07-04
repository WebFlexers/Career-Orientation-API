using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.ProspectiveStudentTestsCompletionState;

public class ProspectiveStudentTestsCompletionStateHandler : 
    IRequestHandler<ProspectiveStudentTestsCompletionStateQuery, ErrorOr<List<GeneralTestCompletionResult>>>
{
    private readonly ITestsRepository _testsRepository;

    public ProspectiveStudentTestsCompletionStateHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<List<GeneralTestCompletionResult>>> Handle(
        ProspectiveStudentTestsCompletionStateQuery request, CancellationToken cancellationToken)
    {
        var testCompletionState = await _testsRepository
            .GetProspectiveStudentTestsCompletionState(request.UserId, cancellationToken);

        return testCompletionState;
    }
}