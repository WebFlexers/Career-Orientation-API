using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.ProspectiveStudentTestsQuestions;

public record ProspectiveStudentTestsQuestionsQuery(
    int GeneralTestId) : IRequest<ErrorOr<ProspectiveStudentTestResult>>;