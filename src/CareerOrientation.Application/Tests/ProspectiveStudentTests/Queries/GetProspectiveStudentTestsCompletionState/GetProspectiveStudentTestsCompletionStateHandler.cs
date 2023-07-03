using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsCompletionState;

public class GetProspectiveStudentTestsCompletionStateHandler : 
    IRequestHandler<GetProspectiveStudentTestsCompletionStateQuery, ErrorOr<List<GeneralTestCompletionResult>>>
{
    private readonly ITestsRepository _testsRepository;

    public GetProspectiveStudentTestsCompletionStateHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<List<GeneralTestCompletionResult>>> Handle(
        GetProspectiveStudentTestsCompletionStateQuery request, CancellationToken cancellationToken)
    {
        var testCompletionState = await _testsRepository
            .GetProspectiveStudentTestsCompletionState(request.UserId, cancellationToken);

        return testCompletionState;
    }
}