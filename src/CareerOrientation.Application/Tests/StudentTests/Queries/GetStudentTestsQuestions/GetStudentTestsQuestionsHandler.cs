using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.StudentTests.Common;
using CareerOrientation.Domain.Common.DomainErrors;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.GetStudentTestsQuestions;

public class GetStudentTestsQuestionsHandler 
    : IRequestHandler<GetStudentTestsQuestionsQuery, ErrorOr<StudentTestResult>>
{
    private readonly ITestsRepository _testsRepository;

    public GetStudentTestsQuestionsHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<StudentTestResult>> Handle(GetStudentTestsQuestionsQuery request, 
        CancellationToken cancellationToken)
    {
        StudentTestResult? universityTest;
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

        if (universityTest is null)
        {
            return Errors.Tests.NoQuestionsFound;
        }

        return universityTest;
    }
}