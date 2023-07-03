using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Grades.Common;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Grades.Queries;

public class FetchStudentGradesHandler : IRequestHandler<FetchStudentGradesQuery, ErrorOr<List<GradeResult>>>
{
    private readonly IGradesRepository _gradesRepository;

    public FetchStudentGradesHandler(IGradesRepository gradesRepository)
    {
        _gradesRepository = gradesRepository;
    }
    
    public async Task<ErrorOr<List<GradeResult>>> Handle(FetchStudentGradesQuery request, 
        CancellationToken cancellationToken)
    {
        var grades = await _gradesRepository.FetchGradesForStudent(request.UserId, cancellationToken);
        return grades;
    }
}