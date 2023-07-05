using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.ProspectiveStudentTestsCompletionState;

/// <summary>
/// Returns a list of all the general tests that the prospective 
/// student can complete whether they have completed each one
/// </summary>
public record ProspectiveStudentTestsCompletionStateQuery(
    string UserId) : IRequest<ErrorOr<List<GeneralTestCompletionResult>>>;