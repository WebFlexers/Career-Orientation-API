using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.HasStudentTakenTest;

/// <summary>
/// Returns whether or not the given student has completed the given university test
/// </summary>
public record HasStudentCompletedTestQuery(
    string UserId,
    int UniversityTestId) : IRequest<ErrorOr<bool>>;