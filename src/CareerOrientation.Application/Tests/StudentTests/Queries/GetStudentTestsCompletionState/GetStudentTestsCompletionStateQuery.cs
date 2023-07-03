using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.GetStudentTestsCompletionState;

public record GetStudentTestsCompletionStateQuery(
    string UserId) : IRequest<ErrorOr<List<IUniversityTestCompletionResult>>>;