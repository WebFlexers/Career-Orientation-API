using CareerOrientation.Application.Courses.Common;

namespace CareerOrientation.Application.Common.Abstractions.Persistence;

public interface ICourseRepository : IRepositoryBase
{
    /// <summary>
    /// Gets the main courses of the given semester and the courses of the given track with their respective skills
    /// </summary>
    Task<List<CoursesWithSkillsResult>> GetCoursesWithSkills(int semester, string trackName, 
        CancellationToken token = default);

    /// <summary>
    /// Gets the courses of the given semester with their respective skills
    /// </summary>
    Task<List<CoursesWithSkillsResult>?> GetCoursesWithSkills(int semester, 
        CancellationToken token = default);
}