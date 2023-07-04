using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.HasStudentTakenTest;

public class HasStudentCompletedTestHandler : IRequestHandler<HasStudentCompletedTestQuery, ErrorOr<bool>>
{
    private readonly ITestsRepository _testsRepository;

    public HasStudentCompletedTestHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<bool>> Handle(HasStudentCompletedTestQuery request, 
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