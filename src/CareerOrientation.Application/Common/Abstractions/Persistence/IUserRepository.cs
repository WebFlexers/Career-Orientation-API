using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface IUserRepository : IRepositoryBase
{
    Task<User?> GetUserById(string userId, CancellationToken cancellationToken);
    Task<UniversityStudent?> GetUniversityStudentById(string? userId, bool includeTrack = true);
    Task AddUniversityStudent(UniversityStudent student);
}