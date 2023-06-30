using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsQuestions;

public record GetProspectiveStudentTestsQuestionsQuery(
    int GeneralTestId) : IRequest<ErrorOr<ProspectiveStudentTestResult>>;