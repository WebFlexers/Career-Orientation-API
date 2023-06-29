using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.StudentTests.Common;
using CareerOrientation.Domain.Common.DomainErrors;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.StudentTests.Queries;

public class GetStudentTestsQuestionsHandler 
    : IRequestHandler<GetStudentTestsQuestionsQuery, ErrorOr<List<StudentTestResult>>>
{
    private readonly ITestsRepository _testsRepository;

    public GetStudentTestsQuestionsHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<List<StudentTestResult>>> Handle(GetStudentTestsQuestionsQuery request, 
        CancellationToken cancellationToken)
    {
        List<StudentTestResult> universityTest;
        if (request.Semester is not null)
        {
            universityTest = await _testsRepository.GetSemesterTestQuestionsWithAnswers(
                request.Semester,
                request.Track,
                cancellationToken);
        }
        else
        {
            universityTest = await _testsRepository.GetRevisionTestQuestionsWithAnswers(
                request.RevisionYear, 
                request.Track,
                cancellationToken);
        }

        if (universityTest.Any() == false)
        {
            return Errors.Tests.NoQuestionsFound;
        }

        return universityTest;
    }
}