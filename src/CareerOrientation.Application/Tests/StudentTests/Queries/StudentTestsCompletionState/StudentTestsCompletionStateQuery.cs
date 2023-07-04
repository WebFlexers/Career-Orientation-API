using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.StudentTestsCompletionState;

/// <summary>
/// Returns a list of all the university tests that the student is required to complete before getting
/// a recommendation and whether they have completed each one
/// </summary>
public record StudentTestsCompletionStateQuery(
    string UserId) : IRequest<ErrorOr<List<IUniversityTestCompletionResult>>>;