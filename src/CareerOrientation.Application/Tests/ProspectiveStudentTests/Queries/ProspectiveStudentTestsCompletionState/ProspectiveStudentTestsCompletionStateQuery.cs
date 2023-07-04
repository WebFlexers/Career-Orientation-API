using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.ProspectiveStudentTestsCompletionState;

// TODO: Rewrite this comment correctly
/// <summary>
/// Returns a list of all the general tests that the student is required to complete before getting
/// a recommendation and whether they have completed each one
/// </summary>
public record ProspectiveStudentTestsCompletionStateQuery(
    string UserId) : IRequest<ErrorOr<List<GeneralTestCompletionResult>>>;