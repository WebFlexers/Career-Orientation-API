using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.StudentTestsQuestions;

/// <summary>
/// Returns the questions of the given test. The test can either be a revision or a standard semester test
/// </summary>
public record StudentTestsQuestionsQuery(
    string? Track,
    int? Semester, 
    int? RevisionYear) : IRequest<ErrorOr<StudentTestResult>>;