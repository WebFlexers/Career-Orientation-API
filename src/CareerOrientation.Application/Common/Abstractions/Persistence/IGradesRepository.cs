using CareerOrientation.Application.Grades.Common;

using ErrorOr;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface IGradesRepository : IRepositoryBase
{
    Task<ErrorOr<List<GradeResult>>> FetchGradesForStudent(string studentId, 
        CancellationToken cancellationToken);
}