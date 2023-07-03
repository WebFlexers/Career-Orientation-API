using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetProspectiveStudentTestsCompletionState;

public record GetProspectiveStudentTestsCompletionStateQuery(
    string UserId) : IRequest<ErrorOr<List<GeneralTestCompletionResult>>>;