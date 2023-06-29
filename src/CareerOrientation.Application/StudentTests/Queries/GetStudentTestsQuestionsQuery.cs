using CareerOrientation.Application.StudentTests.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.StudentTests.Queries;

public record GetStudentTestsQuestionsQuery(
    int? Semester, 
    int? RevisionYear) : IRequest<ErrorOr<List<StudentTestResult>>>;