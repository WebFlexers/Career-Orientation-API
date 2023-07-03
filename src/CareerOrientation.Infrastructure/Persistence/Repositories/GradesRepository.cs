using System.Security.Cryptography;
using System.Text;

using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Grades.Common;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Entities;

using ErrorOr;

using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class GradesRepository : RepositoryBase, IGradesRepository
{
    public GradesRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ErrorOr<List<GradeResult>>> FetchGradesForStudent(string studentId, 
        CancellationToken cancellationToken)
    {
        var student = await _dbContext.UniversityStudents.FindAsync(
            new object?[] {studentId}, 
            cancellationToken);
        if (student is null)
        {
            return Errors.User.StudentNotFoundById;
        }

        IQueryable<Course>? coursesQueryable = _dbContext.Courses.AsNoTracking();

        if (student.IsGraduate == false)
        {
            coursesQueryable = _dbContext.Courses
                .AsNoTracking()
                .Where(c => c.Semester <= student.Semester);
        }

        if (student.Semester >= 5 || student.IsGraduate)
        {
            coursesQueryable = coursesQueryable.Where(c => c.TrackId == student.TrackId || c.TrackId == null);
        }
        
        // Create a deterministic hash to generate the same unique sequence of random grade values for each student
        var hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(studentId));
        var random = new Random(BitConverter.ToInt32(hash, 0));

        var grades = await coursesQueryable
            .OrderBy(c => c.Semester)
            .Select(c => c.MapToGradeResult(random))
            .ToListAsync(cancellationToken);
        
        return grades;
    }
}