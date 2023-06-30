using CareerOrientation.Application.Tests.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.GetStudentTestsQuestions;

public record GetStudentTestsQuestionsQuery(
    string? Track,
    int? Semester, 
    int? RevisionYear) : IRequest<ErrorOr<StudentTestResult>>;