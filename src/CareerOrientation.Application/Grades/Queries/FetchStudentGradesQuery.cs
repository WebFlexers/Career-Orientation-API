using CareerOrientation.Application.Grades.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Grades.Queries;

public record FetchStudentGradesQuery(string UserId) : IRequest<ErrorOr<List<GradeResult>>>;