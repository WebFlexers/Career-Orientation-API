using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetHasProspectiveStudentTakenTest;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.GetHasStudentTakenTest;

public class GetHasStudentTakenTestHandler : IRequestHandler<GetHasStudentTakenTestQuery, ErrorOr<bool>>
{
    private readonly ITestsRepository _testsRepository;

    public GetHasStudentTakenTestHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<bool>> Handle(GetHasStudentTakenTestQuery request, 
        CancellationToken cancellationToken)
    {
        var result = await _testsRepository.EnsureUserHasntTakenTest(
            request.UserId, request.UniversityTestId, TestType.UniversityTest, cancellationToken);

        if (result.IsError == false)
        {
            // If there were no errors it means that the user hasn't taken the test
            return false;
        }
        
        if (result.Errors.Any(e => e.Code == Errors.Tests.StudentAlreadyTookTest.Code))
        {
            return true;
        }

        return result.Errors;
    }
}