using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;
using CareerOrientation.Domain.Common.DomainErrors;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsQuestions;

public class GetProspectiveStudentTestsQuestionsHandler : 
    IRequestHandler<GetProspectiveStudentTestsQuestionsQuery, ErrorOr<ProspectiveStudentTestResult>>
{
    private readonly ITestsRepository _testsRepository;

    public GetProspectiveStudentTestsQuestionsHandler(ITestsRepository testsRepository)
    {
        _testsRepository = testsRepository;
    }
    
    public async Task<ErrorOr<ProspectiveStudentTestResult>> Handle(
        GetProspectiveStudentTestsQuestionsQuery request, 
        CancellationToken cancellationToken)
    {
        var studentTestResult =
            await _testsRepository.GetGeneralTestQuestionsWithAnswers(request.GeneralTestId, cancellationToken);

        if (studentTestResult is null)
        {
            return Errors.Tests.NoQuestionsFound;
        }

        return studentTestResult;
    }
}