using CareerOrientation.Application.ProspectiveStudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsQuestions;

public record GetProspectiveStudentTestsQuestionsQuery(
    int GeneralTestId) : IRequest<ErrorOr<ProspectiveStudentTestResult>>;